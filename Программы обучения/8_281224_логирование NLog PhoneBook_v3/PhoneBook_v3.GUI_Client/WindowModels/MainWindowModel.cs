using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using NLog;
using PhoneBook_v3.BL;
using PhoneBook_v3.BL.Models;

namespace PhoneBook_v3.GUI_Client.WindowModels;

public class MainWindowModel : WindowModelBase
{
    private static readonly Logger Logger = NLog.LogManager.GetCurrentClassLogger();
    
    #region Observable Properties

    private string? _searchText;
    public string? SearchText
    {
        get => _searchText;
        set => SetField(ref _searchText, value);
    }

    private string? _id;
    public string? Id
    {
        get => _id;
        set => SetField(ref _id, value);
    }
    
    private string? _name;
    public string? Name
    {
        get => _name;
        set => SetField(ref _name, value);
    }
    
    private string? _lastName;
    public string? LastName
    {
        get => _lastName;
        set => SetField(ref _lastName, value);
    }
    
    private string? _patronymic;
    public string? Patronymic
    {
        get => _patronymic;
        set => SetField(ref _patronymic, value);
    }
    
    private Contact? _selectedContact;
    public Contact? SelectedContact 
    {
        get => _selectedContact;
        set
        {
            var result = SetField(ref _selectedContact, value);
            if (result)
            {
                Id = _selectedContact.Id.ToString();
                Name = _selectedContact.Name;
                LastName = _selectedContact.LastName;
                Patronymic = _selectedContact.Patronymic;
                ObservableInit(_selectedContact.Phones);
            }
        }
    }

    public ObservableCollection<Contact> Contacts { get; init; } = [];
    public ObservableCollection<Phone> Phones { get; init; } = [];

    #endregion

    #region Commands

    public ICommand CommandSearch { get; init; }
    public ICommand CommandSave { get; init; }
    public ICommand CommandDelete { get; init; }
    public ICommand CommandClear { get; }
    public ICommand CommandSearchTextIsEmpty { get; init; }

    #endregion
    
    #region Constructors

    private readonly PhoneBook _phoneBook;
    
    public MainWindowModel()
    {
        try
        {
            _phoneBook = new PhoneBook("mongodb://localhost:27017");
            var contacts = _phoneBook.GetAll();
            ObservableInit(contacts);
        }
        catch (Exception e)
        {
            Logger.Fatal(e, "Ошибка подключения к БД");

            var result = MessageBox.Show("Ошибка подключения к БД");
            if (result == MessageBoxResult.OK)
            {
                Application.Current.Shutdown();
            }
            else
            {
                throw;
            }
        }

        CommandClear = new LambdaCommand(
            execute: _ =>
            {
                ClearInputs();
            },
            canExecute: _ => !string.IsNullOrWhiteSpace(Id) 
                             || !string.IsNullOrWhiteSpace(Name)
                             || !string.IsNullOrWhiteSpace(LastName)
                             || !string.IsNullOrWhiteSpace(Patronymic));
        
        CommandDelete = new LambdaCommand(
            execute: _ =>
            {
                _phoneBook.DeleteContact(SelectedContact!);
            },
            canExecute: _ => SelectedContact is not null);
        
        CommandSave = new LambdaCommand(
            execute: _ =>
            {
                if (SelectedContact is not null)
                {
                    _phoneBook.UpdateContact(SelectedContact!);
                }
                else
                {
                    _phoneBook.AddContact(new Contact()
                    {
                        Name = Name!, 
                        LastName = LastName, 
                        Patronymic = Patronymic,
                        Phones = Phones.ToList()
                    });
                }
            },
            canExecute: _ =>  !string.IsNullOrWhiteSpace(Name)
                              || !string.IsNullOrWhiteSpace(LastName)
                              || !string.IsNullOrWhiteSpace(Patronymic));

        CommandSearch = new LambdaCommand(
            execute: _ =>
            {
                ClearInputs();
                Contacts.Clear();
                
                var contactsByName = _phoneBook.FindAllByName(SearchText!);
                var contactsByPhone = _phoneBook.FindAllByPhone(SearchText!);
                var contactsByComment = _phoneBook.FindAllByComment(SearchText!);

                if (contactsByName is not null && contactsByName.Any())
                {
                    foreach (var contact in contactsByName)
                    {
                        Contacts.Add(contact);
                    }
                }

                if (contactsByPhone is not null && contactsByPhone.Any())
                {
                    foreach (var contact in contactsByPhone)
                    {
                        Contacts.Add(contact);
                    }
                }

                if (contactsByComment is not null && contactsByComment.Any())
                {
                    foreach (var contact in contactsByComment)
                    {
                        Contacts.Add(contact);
                    }
                }
            },
            canExecute: _ => !string.IsNullOrWhiteSpace(SearchText));

        CommandSearchTextIsEmpty = new LambdaCommand(
            execute: _ =>
            {
                if (!string.IsNullOrWhiteSpace(SearchText)) return;
                
                ClearInputs();
                
                Contacts.Clear();
                var collection = _phoneBook.GetAll();
                ObservableInit(collection);
            });
    }
    
    #endregion

    #region Methods

    private void ObservableInit<T>(IEnumerable<T> collection)
    {
        if (typeof(T) == typeof(Contact))
        {
            Contacts.Clear();
            
            foreach (var item in collection)
            {
                var contact = item as Contact;
                Contacts.Add(contact!);
            }
        }
        else if (typeof(T) == typeof(Phone))
        {
            Phones.Clear();

            foreach (var item in collection)
            {
                var phone = item as Phone;
                Phones.Add(phone!);
            }
        }
    }

    private void ClearInputs()
    {
        Id = null;
        Name = null;
        LastName = null;
        Patronymic = null;
        
        Phones.Clear();
    }

    #endregion
}
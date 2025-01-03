﻿using MongoDB.Bson;
using MongoDB.Driver;
using PhoneBook_v3.BL.Models;

namespace PhoneBook_v3.BL;

public partial class PhoneBook
{
    private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
    
    private readonly IMongoCollection<Contact> _collection;
    
    public PhoneBook(string connectionString)
    {
        try
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("phonebook_db");
            _collection = database.GetCollection<Contact>("phonebook");
            
            _collection.Find(new BsonDocument()).ToList();
            Logger.Info("База данных доступна");
        }
        catch (Exception e)
        {
            Logger.Fatal(e, "База данных не доступна");
            throw;
        }
    }
    
    public bool AddContact(Contact contact) //TODO
    {
        _collection.InsertOne(contact);
        return true;
    }
    
    public bool UpdateContact(Contact contact) //TODO
    {
        //_collection.FindOneAndReplace(new BsonDocument("_id", contact.Id), contact);
        
        var filter = Builders<Contact>.Filter.Eq(p=>p.Id, contact.Id);
        _collection.FindOneAndReplace(filter, contact);
        
        return true;
    }
    
    public bool DeleteContact(Contact contact) //TODO
    {
        var filter = Builders<Contact>.Filter.Eq(p=>p.Id, contact.Id);
        _collection.DeleteOne(filter);

        return true;
    }
}
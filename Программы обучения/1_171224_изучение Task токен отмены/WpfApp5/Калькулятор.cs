namespace WpfApp5;

public static class Калькулятор
{
    public static long Факториал(int число)
    {
        if (число == 0) return 1;
        Task.Delay(1000).Wait();
        return число * Факториал(число - 1);
    }
    // параметры функций добавлен токен отмены CancellationToken cancellationToken = default
    // токен отмены - это просто переменная которая содержит состояние и мы должны сами проверять в нужный 
    //     момент времени 
    // токен отмены должен участвовать во всех асинхронных вызовах внутри асинхронного метода 
    public static async Task<long> ФакториалAsync(int number, CancellationToken cancellationToken = default, IProgress<int>? progress = null)
    {
        return await Task.Run(async () =>
        {
            long factorial = 1;

            for (int i = number; i > 1; i--)
            {
                cancellationToken.ThrowIfCancellationRequested();
                
                progress?.Report(number - i);
                factorial *= i;
                await Task.Delay(1000, cancellationToken); // токен отмены обязаны передать в Task.Delay
            }
            
            return factorial;
        });
    }

    public static async Task<long> СуммаAsync(int число, CancellationToken cancellationToken = default, IProgress<int>? progress = null)
    {
        return await Task.Run(async () =>
        {
            long sum = 0;
            for (int i = число; i > 0; i--)
            {
                /*if (cancellationToken.HasValue && cancellationToken.Value.IsCancellationRequested)
                {
                    //return sum;
                    throw new OperationCanceledException();
                }*/

                cancellationToken.ThrowIfCancellationRequested();
                
                progress?.Report(число - i);
                sum += i;
                await Task.Delay(100, cancellationToken);
            }

            return sum;
        });
    }
}
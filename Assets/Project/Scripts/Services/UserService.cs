using System;
using RedPanda.Project.Services.Interfaces;

namespace RedPanda.Project.Services
{
    public sealed class UserService : IUserService
    {
        public event Action<int> CurrencyChanged;
        public int Currency { get; private set; } = 1000;

        void IUserService.AddCurrency(int delta)
        {
            Currency += delta;
            CurrencyChanged?.Invoke(Currency);
        }

        void IUserService.ReduceCurrency(int delta)
        {
            Currency -= delta;
            CurrencyChanged?.Invoke(Currency);
        }
        
        bool IUserService.HasCurrency(int amount)
        {
            return Currency >= amount;
        }
    }
}
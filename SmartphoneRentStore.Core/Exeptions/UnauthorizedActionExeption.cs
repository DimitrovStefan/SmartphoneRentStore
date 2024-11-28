namespace SmartphoneRentStore.Core.Exeptions
{
    using System;

    public class UnauthorizedActionExeption : Exception // Creating own exeption
    {
        public UnauthorizedActionExeption()
        {
                
        }

        public UnauthorizedActionExeption(string message) 
            : base(message)
        {
            
        }
    }
}

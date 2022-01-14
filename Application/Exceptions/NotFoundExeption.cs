using System;
namespace Application.Exceptions
{
    public class NotFoundExeption : Exception
    {
        public NotFoundExeption(string name, object key, string propertyName)
            : base($"Entity : '{name}' with property of '{propertyName}' : {key} was not found")
        {

        }
    }

}

using System.Collections.Generic;
using System.Runtime.InteropServices;
using OSS.Domain.Common.Models.DbModels;

namespace OSS.Domain.Common.SeedData
{
    public class Orders
    {
        public readonly List<OrderDbModel> orders = new List<OrderDbModel>
        {
            new OrderDbModel()
            {
                Address = "Комсомольская 27/1 - 13",
                ClientName = "Пупкин Василий",
                OrderNumber = "dog111-1111",
                Phone = "37529 999 123_321",
                FinalSum = 1_000_000,
            },
            new OrderDbModel()
            {
                Address = "Радужная 105/4 - 23",
                ClientName = "Петухов Валерий",
                OrderNumber = "dog123_321",
                Phone = "37529 888 88 88",
                FinalSum = 1_000,
            },
            new OrderDbModel()
            {
                Address = "Каменодырская 1432/43 - 123_321",
                ClientName = "Головач Елена",
                OrderNumber = "dog333-3333",
                Phone = "37529 777 77 77",
                FinalSum = 1_223,
            },
            new OrderDbModel()
            {
                Address = "Зыбицкая 12-11",
                ClientName = "Махмуд Абдурахман 123_321",
                OrderNumber = "dog444-4444",
                Phone = "37529 666 66 66",
                FinalSum = 1_000_111,
            },
            new OrderDbModel()
            {
                Address = "Некрасова 25-82",
                ClientName = "Иванов Иван",
                OrderNumber = "dog555-5555",
                Phone = "37529 555 55 55",
                FinalSum = 123_321,
            },
        };
    }
}
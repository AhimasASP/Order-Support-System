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
                Comment = "съешь ещё этих мягких французских булок, да выпей чаю",
            },
            new OrderDbModel()
            {
                Address = "Радужная 105/4 - 23",
                ClientName = "Петухов Валерий",
                OrderNumber = "dog123_321",
                Phone = "37529 888 88 88",
                FinalSum = 1_000,
                Comment = "съешь ещё этих мягких французских булок, да выпей чаю",
            },
            new OrderDbModel()
            {
                Address = "Каменодырская 1432/43 - 123_321",
                ClientName = "Головач Елена",
                OrderNumber = "dog333-3333",
                Phone = "37529 777 77 77",
                FinalSum = 1_223,
                Comment = "съешь ещё этих мягких французских булок, да выпей чаю",
            },
            new OrderDbModel()
            {
                Address = "Зыбицкая 12-11",
                ClientName = "Махмуд Абдурахман 123_321",
                OrderNumber = "dog444-4444",
                Phone = "37529 666 66 66",
                FinalSum = 1_000_111,
                Comment = "съешь ещё этих мягких французских булок, да выпей чаю",
            },
            new OrderDbModel()
            {
                Address = "Некрасова 25-82",
                ClientName = "Иванов Иван",
                OrderNumber = "dog555-5555",
                Phone = "37529 555 55 55",
                FinalSum = 123_321,
                Comment = "съешь ещё этих мягких французских булок, да выпей кофе",
            },
            new OrderDbModel()
            {
                Address = "Пионерская 23/1 - 113",
                ClientName = "Зябликов Викентий",
                OrderNumber = "dog222-1212",
                Phone = "37529 999 1233211",
                FinalSum = 1_000,
                Comment = "съешь ещё этих мягких французских булок, да выпей чаю",
            },
            new OrderDbModel()
            {
                Address = "Солнечная 10/2 - 123",
                ClientName = "Маяковский Владимир",
                OrderNumber = "dog123_444",
                Phone = "37529 900 09 09",
                FinalSum = 1_123_100,
                Comment = "съешь ещё этих мягких французских булок, да выпей чаю",
            },
            new OrderDbModel()
            {
                Address = "Сухаревская 143/42",
                ClientName = "Прокопова Ефросиня",
                OrderNumber = "dog344-3333",
                Phone = "37529 444 33 22",
                FinalSum = 1_999,
                Comment = "съешь ещё этих мягких французских булок, да выпей чаю",
            },
            new OrderDbModel()
            {
                Address = "Октябрьская 12-11",
                ClientName = "Абдула Али",
                OrderNumber = "dog999-9999",
                Phone = "37529 123 22 33",
                FinalSum = 1_023_111,
                Comment = "съешь ещё этих мягких французских булок, да выпей чаю",
            },
            new OrderDbModel()
            {
                Address = "Красная 22-182",
                ClientName = "Круглов Петр",
                OrderNumber = "dog625-1244",
                Phone = "37529 554 66 77",
                FinalSum = 12_321,
                Comment = "съешь ещё этих мягких французских булок, да выпей кофе",
            },  new OrderDbModel()
            {
                Address = "Комсомольская 27/1 - 13",
                ClientName = "Пупкин Василий",
                OrderNumber = "dog111-1111",
                Phone = "37529 999 123_321",
                FinalSum = 1_000_000,
                Comment = "съешь ещё этих мягких французских булок, да выпей чаю",
            },
            new OrderDbModel()
            {
                Address = "Радужная 105/4 - 23",
                ClientName = "Петухов Валерий",
                OrderNumber = "dog123_321",
                Phone = "37529 888 88 88",
                FinalSum = 1_000,
                Comment = "съешь ещё этих мягких французских булок, да выпей чаю",
            },
            new OrderDbModel()
            {
                Address = "Каменодырская 1432/43 - 123_321",
                ClientName = "Головач Елена",
                OrderNumber = "dog333-3333",
                Phone = "37529 777 77 77",
                FinalSum = 1_223,
                Comment = "съешь ещё этих мягких французских булок, да выпей чаю",
            },
            new OrderDbModel()
            {
                Address = "Зыбицкая 12-11",
                ClientName = "Махмуд Абдурахман 123_321",
                OrderNumber = "dog444-4444",
                Phone = "37529 666 66 66",
                FinalSum = 1_000_111,
                Comment = "съешь ещё этих мягких французских булок, да выпей чаю",
            },
            new OrderDbModel()
            {
                Address = "Некрасова 25-82",
                ClientName = "Иванов Иван",
                OrderNumber = "dog555-5555",
                Phone = "37529 555 55 55",
                FinalSum = 123_321,
                Comment = "съешь ещё этих мягких французских булок, да выпей кофе",
            },
            new OrderDbModel()
            {
                Address = "Дружная 223/12 - 13",
                ClientName = "Куликов Павел",
                OrderNumber = "dog202-5326",
                Phone = "37529 999 98477345",
                FinalSum = 1_334,
                Comment = "съешь ещё этих мягких французских булок, да выпей чаю",
            },
            new OrderDbModel()
            {
                Address = "Озерная 120/22 - 12",
                ClientName = "Туманов Валентин",
                OrderNumber = "dog6564_3434",
                Phone = "37529 482 35 03",
                FinalSum = 1_100,
                Comment = "съешь ещё этих мягких французских булок, да выпей чаю",
            },
            new OrderDbModel()
            {
                Address = "Ташкентская 13/142",
                ClientName = "Рудакопова Алевтина",
                OrderNumber = "dog324-94753",
                Phone = "37529 123 33 22",
                FinalSum = 999,
                Comment = "съешь ещё этих мягких французских булок, да выпей чаю",
            },
            new OrderDbModel()
            {
                Address = "Свободная 12-222",
                ClientName = "Джэк Дэниэлз",
                OrderNumber = "dog9123-5543",
                Phone = "37529 999 99 33",
                FinalSum = 1_000_000_000,
                Comment = "съешь ещё этих мягких французских булок, да выпей чаю",
            },
            new OrderDbModel()
            {
                Address = "Круглая 2-12",
                ClientName = "Машкин Федор",
                OrderNumber = "dog654-998",
                Phone = "37529 432 54 54",
                FinalSum = 769,
                Comment = "съешь ещё этих мягких французских булок, да выпей кофе",
            },
        };
    }
}
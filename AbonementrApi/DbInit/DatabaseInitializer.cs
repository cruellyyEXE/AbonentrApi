using Dapper;
using Data.Context;

namespace Api.DbInit;

public static class DatabaseInitializer
{
    public static async Task InitializeAsync()
    {
        await AbonentrContext.Connection.OpenAsync();
        
         await AbonentrContext.Connection.ExecuteAsync("CREATE TABLE IF NOT EXISTS re_abonents(" +
                                       "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, " +
                                       "first_name VARCHAR(50) NOT NULL, " +
                                       "last_name VARCHAR(50) NOT NULL, " +
                                       "patronymic VARCHAR(50) NOT NULL);");

         await AbonentrContext.Connection.ExecuteAsync(
             "insert or ignore into re_abonents (id, first_name, last_name, patronymic) " +
             "values (1, 'Емельянов', 'Антон', 'Анатольевич');" + 
             "insert or ignore into re_abonents (id, first_name, last_name, patronymic) " +
             "values (2, 'Твердый', 'Глеб', 'Григорьевич');" + 
             "insert or ignore into re_abonents (id, first_name, last_name, patronymic) " +
             "values (3, 'Мягкий', 'Дмитрий', 'Игоревич');" +
             "insert or ignore into re_abonents (id, first_name, last_name, patronymic) " +
             "values (4, 'Жидко', 'Павел', 'Глебович');" +
             "insert or ignore into re_abonents (id, first_name, last_name, patronymic) " +
             "values (5, 'Колосс', 'Григорий', 'Павлович');");
         
         await AbonentrContext.Connection.ExecuteAsync("CREATE TABLE IF NOT EXISTS dir_phone_number_types(" +
                                       "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, " +
                                       "name VARCHAR(50) NOT NULL);");

         await AbonentrContext.Connection.ExecuteAsync(
             "insert or ignore into dir_phone_number_types (id, name) values (1, 'Домашний');" + 
             "insert or ignore into dir_phone_number_types (id, name) values (2, 'Рабочий');" + 
             "insert or ignore into dir_phone_number_types (id, name) values (3, 'Мобильный');");
         
         await AbonentrContext.Connection.ExecuteAsync("CREATE TABLE IF NOT EXISTS dir_streets(" +
                                       "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, " +
                                       "name VARCHAR(50) NOT NULL);");

         await AbonentrContext.Connection.ExecuteAsync(
             "insert or ignore into dir_streets (id, name) values (1, 'Красная');" + 
             "insert or ignore into dir_streets (id, name) values (2, 'Бабушкина');" + 
             "insert or ignore into dir_streets (id, name) values (3, 'Головатого');" + 
             "insert or ignore into dir_streets (id, name) values (4, 'Дзержинского');");

         await AbonentrContext.Connection.ExecuteAsync("CREATE TABLE IF NOT EXISTS re_addresses(" +
                                       "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, " +
                                       "country VARCHAR(50) NOT NULL, " +
                                       "town VARCHAR(50) NOT NULL, " +
                                       "street VARCHAR(50) NOT NULL, " +
                                       "house VARCHAR(50) NOT NULL, " +
                                       "abonent_id INTEGER NOT NULL, " +
                                       "FOREIGN KEY (abonent_id) REFERENCES re_abonents(id));");

         await AbonentrContext.Connection.ExecuteAsync(
             "insert or ignore into re_addresses (id, country, town, street, house, abonent_id) " +
             "values (1, 'Россия', 'Краснодар', 'Красная', '12', 1);" + 
             "insert or ignore into re_addresses (id, country, town, street, house, abonent_id) " +
             "values (2, 'Россия', 'Краснодар', 'Красная', '34', 2);" + 
             "insert or ignore into re_addresses (id, country, town, street, house, abonent_id) " +
             "values (3, 'Россия', 'Краснодар', 'Бабушкина', '126', 3);" +
             "insert or ignore into re_addresses (id, country, town, street, house, abonent_id) " +
             "values (4, 'Россия', 'Краснодар', 'Головатого', '9', 4);" +
             "insert or ignore into re_addresses (id, country, town, street, house, abonent_id) " +
             "values (5, 'Россия', 'Краснодар', 'Дзержинского', '234', 5);");
         
         await AbonentrContext.Connection.ExecuteAsync("CREATE TABLE IF NOT EXISTS re_phone_numbers(" +
                                       "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, " +
                                       "number VARCHAR(50) NOT NULL, " +
                                       "abonent_id INTEGER NOT NULL, " +
                                       "type_id INTEGER NOT NULL," +
                                       "FOREIGN KEY (type_id) REFERENCES dir_phone_number_types(id)," +
                                       "FOREIGN KEY (abonent_id) REFERENCES re_abonents(id));");

         await AbonentrContext.Connection.ExecuteAsync(
             "insert into re_phone_numbers (id, number, abonent_id, type_id) " +
             "values (1, '+7 (099) 234-11-22', 1, 1), " +
             "(2, '+7 (889) 134-13-22', 1, 2), " +
             "(3, '+7 (589) 264-11-25', 2, 2), " +
             "(4, '+7 (489) 834-61-29', 2, 3), " +
             "(5, '+7 (487) 834-11-29', 3, 3), " +
             "(6, '+7 (489) 834-17-29', 4, 1), " +
             "(7, '+7 (170) 734-21-22', 5, 2);");
    }
}
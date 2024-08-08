namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DeleteByMask(@"C:\Users\Brill\Desktop\Для удаления", @"*.txt");
        }
        static void DeleteByMask(string path, string mask)
        {
            if(path is null) throw new ArgumentNullException();
            if(mask is null) throw new ArgumentNullException();
            if(!Directory.Exists(path)) throw new FileNotFoundException();
            foreach (var item in Directory.GetFiles(path, mask))
            {
                File.Delete(item);
            }
            foreach (var item in Directory.GetDirectories(path))
            {
                var tempPath = Path.Combine(item);
                DeleteByMask(tempPath, mask);
                Directory.Delete(tempPath, true);
            }
        }
    }
}

//Задание 3:
//Разработайте приложение для удаления файлов по маске. Пользователь вводит путь к папке и маску для поиска удаляемых файлов. Например:
//D:\DataForUser
//*.txt
//Приложение должно удалить все файлы с расширением txt по пути D:\DataForUser
//Задание 4:
//Добавьте к третьему заданию удаление файлов в подпапках.
//Задание 5:
//Добавьте к третьему заданию удаление подпапок в папках.
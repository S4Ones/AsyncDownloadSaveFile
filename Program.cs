namespace AsyncDownloadSaveFile
{
    internal class Program
    {
        /// <summary>
        /// Ввод URL и путь к файлу.
        /// </summary>
        static async Task Main()
        {
            Console.WriteLine("Введите URL файла для загрузки:");
            string fileUrl = Console.ReadLine();

            Console.WriteLine("Введите путь для сохранения файла:");
            string filePath = Console.ReadLine();

            await DownloadFileAsync(fileUrl, filePath);

            Console.WriteLine("Загрузка и сохранение файла завершены.");
        }

        #region Асинхронный метод сохранения и загрузки

        /// <summary>
        /// Загрузка и сохранение файла.
        /// </summary>
        /// <param name="fileUrl">URL адрес</param>
        /// <param name="filePath">Путь к файлу</param>
        static async Task DownloadFileAsync(string fileUrl, string filePath)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    byte[] fileBytes = await httpClient.GetByteArrayAsync(fileUrl);

                    using (FileStream fileStream = File.Create(filePath))
                    {
                        await fileStream.WriteAsync(fileBytes);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка при загрузке и сохранении файла: {ex.Message}");
                }
            }
        }

        #endregion
    }
}
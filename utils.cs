

public static class utils
{
    //FileAccess for importing .csv with users data from a diabetes device
    public static string[] FileImport ()
    {
        int lineCount = 0;
        string[] lines = new string[lineCount];
        OpenFileDialog openFileDialog = new OpenFileDialog()
        {
            Filter = "CSV-Datei .csv | *.csv",
            Title = "CSV Datei Import",
            InitialDirectory = "C:/Temp/"
        };


        if(openFileDialog.ShowDialog() == DialogResult.OK)
        {
            
            try
            {
                var sr = new StreamReader(openFileDialog.FileName);
                
                while (!sr.EndOfStream)
                {
                    lineCount++;
                    Array.Resize(ref lines, lineCount);
                    lines[lineCount -1] = sr.ReadLine();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        return lines;
    }

    public static void FileExport(string[] values)
    {
        throw new NotImplementedException();
    }
}
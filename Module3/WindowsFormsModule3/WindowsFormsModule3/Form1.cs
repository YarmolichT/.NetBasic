using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Tulpep.NotificationWindow;


namespace WindowsFormsModule3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            

        }

        public PopupNotifier popup;

        public delegate string[] FilterItems(string PathToFolder);

        //public List<string> listOfFiles = new List<string>();


        public class FileSystemVisitor
        {

            public FilterItems filteringListItems;

            
            public void RegisterHandler(FilterItems FilterFolders)
            {
                filteringListItems = FilterFolders;
            }

            public FileSystemVisitor() { 
            
            }

            public string stringToFind1;

            public FileSystemVisitor(string stringToFind)
            {
                stringToFind1 = stringToFind;
            }

            

            public IEnumerable GetFiles(string PathToFolder)
            {
                string[] allfiles = Directory.GetFiles(PathToFolder);
                for (int i = 0; i < allfiles.Length; i++)
                {     
                       yield return allfiles[i];    
                }
            }

            public IEnumerable GetFolders(string PathToFolder)
            {
                string[] allFolders = Directory.GetFileSystemEntries(PathToFolder);
                for (int i = 0; i < allFolders.Length; i++)
                {
                    yield return allFolders[i];
                }
            }

            public string[]  FilterFolders( string PathToFolder)
            {                            
                string[] allFolders = Directory.GetFileSystemEntries(PathToFolder);
                
                string[] result = Array.FindAll(allFolders, element => element.Contains(stringToFind1));
                
                return result.ToArray() ;
            }

            public string[] GetFileFoldersForPredicate(string PathToFolder)
            {
              
                string[] allFolders = Directory.GetFileSystemEntries(PathToFolder);
                
                return allFolders;
            }

            public bool IsExcludeFile(string name /*string valueForExclude*/)
            {
                Form1 form1 = new Form1();
               
                if (name.Contains(/*form1.valueForExclude)*/ "E"))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
           

        }

       

       
        private void btnShowFiels_Click(object sender, EventArgs e)
        {
                     
            var fileSystemVisitor = new FileSystemVisitor();

            string PathToFolder = $"{txtSourceDolder.Text}";
                      
           
            foreach (string file in fileSystemVisitor.GetFiles(PathToFolder))
            {    
                listView1.Items.Add(file);
            }

            foreach (string folders in fileSystemVisitor.GetFolders(PathToFolder))
            {
                listView1.Items.Add(folders);
            }



        }

      

        
        public class MyEventCreator
        {
            public delegate void NotificationHandler();
            public event NotificationHandler StartFiltering;
            public event NotificationHandler FinishFiltering;

            public void OnStartFiltering()
            {
                NotificationHandler handler = StartFiltering;
                handler?.Invoke();
            }

            public void OnFinishFiltering()
            {
                FinishFiltering();
            }

            
        }

        public class EventMethods {
            
            public void MsgBoxStart()
            {
                
                MessageBox.Show("We started filtering.");
            }

            public void MsgBoxFinish()
            {
                MessageBox.Show("We finished.");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            EventMethods eventMethods = new EventMethods();
           MyEventCreator myEventCreator = new MyEventCreator();

            myEventCreator.StartFiltering += eventMethods.MsgBoxStart;
            myEventCreator.FinishFiltering += eventMethods.MsgBoxFinish;

            myEventCreator.OnStartFiltering() ;

            listView1.Items.Clear();

            string stringToFind = $"{txtFilterByFilesFolder.Text}";
            string PathToFolder = $"{txtSourceDolder.Text}";

            FileSystemVisitor fileSystemVisitor = new FileSystemVisitor(stringToFind);

            fileSystemVisitor.RegisterHandler(fileSystemVisitor.FilterFolders);

            string[] fileteredResult = fileSystemVisitor.filteringListItems(PathToFolder);


            foreach (string folders in fileteredResult)
            {
                listView1.Items.Add(folders);
            }

            myEventCreator.OnFinishFiltering();
            
        }

       /* static  void AppConfig()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("confg.json");

             AppConfiguration = builder.Build();
        }
        
        static IConfiguration AppConfiguration { get; set; }
        
        string valueForCancel = AppConfiguration["valueForCancel"];
        string valueForExclude = AppConfiguration["valueForExclude"];*/


        

        private void buttonPredicate_Click(object sender, EventArgs e)
        {  
            string PathToFolder = $"{txtSourceDolder.Text}";
            var fileSystemVisitor = new FileSystemVisitor();
            string[] filteredResult = fileSystemVisitor.GetFileFoldersForPredicate(PathToFolder);

            listView1.Items.Clear();

            foreach (string file in filteredResult)
            {
     
                if (fileSystemVisitor.IsExcludeFile(file)) {
                    listView1.Items.Add(file);
                }
            }
           
        }


        

    }
}

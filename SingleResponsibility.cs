using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    /*
     *  This file desmonstrates the use of Single Responsibility principle.
     *  The class Journal is only responsible for Journal entries
     *  The class Persistance is only responsible for saving a file
     */
    internal class SingleResponsibility
    {

        public void Start()
        {
            Journal myJournal = new Journal();
            myJournal.AddEntry("I Read Design Patterns");
            myJournal.AddEntry("I had my dinner");
            myJournal.AddEntry("I coocked my meal");

            var saveJournal = new Persistance();
            string fileName = @"c:\temp\MyJournal.txt";
            saveJournal.SaveToFile(myJournal, fileName, true);
            saveJournal.LoadFile(fileName);
        }
    }

    public class Journal
    {
        public readonly List<string> entries = new List<string>();

        public static int count;

        public void AddEntry(string item)
        {
            entries.Add($"{++count}. {item}");
        }

        public int Count()
        {
            return count;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }

    public class Persistance
    {
        public void SaveToFile(Journal journal, string fileName, bool overwrite = false)
        {
            if(overwrite || !File.Exists(fileName))
            {
                File.WriteAllText(fileName, journal.ToString());
            }
        }

        public void LoadFile(string fileName)
        {
            Process.Start(fileName);
        }
    }
}

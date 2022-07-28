using CsvHelper;
using CsvHelper.Configuration;
using DocumentFormat.OpenXml.Spreadsheet;
using member;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Call_logger
{
    class Program
    {
        static string Main(string[] args)
        {
            List<Member> memberList = ReadMembers();
            {
                var member = new Member();
                string MemberName;
                int CallLength = 0;
                string Resolved;
                string userInput;
                int memberId = 0;




                do
                {
                    Console.WriteLine("Do you need to document a new call? Please type 'yes' or 'no'. ");
                    userInput = Console.ReadLine();
                    { 
                        case "no";
                        new Member();
                        break;
                    }

                    if (userInput != "no") ;
                    {
                        member = new Member();
                        Console.WriteLine("Please enter the first name of your caller.");
                        member.MemberName = Console.ReadLine();
                        Console.WriteLine("Please enter the member ID for your member.");
                        member.memberId = Console.ReadLine();
                        Console.WriteLine("Please enter the lenght of your call in minutes.");
                        member.CallLength = Console.ReadLine();
                        Console.WriteLine("Was the issue resolved?");
                        member.Resolved = Console.ReadLine();
                        memberList.Add(member);

                    }
                    else

                    {
                        int counter = 1;
                        foreach (Member member in memberList)
                        {
                            Console.WriteLine(counter.ToString() + ", " + MemberName + " " + memberId + " " + CallLength + " call resolved: " + Resolved + " .");

                        }

                        DateTime today = DateTime.Today;
                        int daysUntilFriday = ((int)DayOfWeek.Friday - (int)today.DayOfWeek + 7) % 7;
                        DateTime nextFriday = today.AddDays(daysUntilFriday);


                        Console.WriteLine("Which member would you like to view?");
                        var v = Convert.ToInt32((Console.ReadLine()));
                        Console.WriteLine("If this member's inquiry is not resolved please call them back by Friday. Which is in " + daysUntilFriday + " days.");



                    }






                } while (userInput != "exit");

                WriteMembers(memberList);







            }










        }
        public static void WriteMembers(List<Member> memberList)
        {
            using (var writer = new StreamWriter("MemberList.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(members);
            }
            public static List<Member> ReadMembers()
            {

                var CSVConfig = new CsvConfiguration(CultureInfo.CurrentCulture);
                using var StreamReader = File.OpenText("MemberList.csv");
                using var csvReader = new CsvReader(StreamReader, CSVConfig);
                string GetData;
                var isLineOne = true;
                List<Member> memberList = new List<Member>();


                while (csvReader.Read())
                {
                    if (isLineOne == true)
                    {

                        isLineOne = false;
                    }
                    else

                    {
                        Member member = new Member();
                        string Name;
                        int Id;
                        string Resolved;
                        string calllength;
                        csvReader.TryGetField<string>(0, out Name);
                        csvReader.TryGetField<int>(1, out Id);
                        csvReader.TryGetField<string>(2, out Resolved);
                        csvReader.TryGetField<string>(3, out calllength);
                        member.MemberName = Name;
                        member.memberId = Id;
                        member.Resolved = Resolved;
                        member.CallLength = calllength;

                        memberList.Add(member);

                    }



                }
                StreamReader.Close();
                csvReader.Dispose();
                return memberList;


            }
        }






    }














}

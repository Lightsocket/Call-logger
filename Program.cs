﻿using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;


namespace Call_logger
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Member> memberList = ReadMembers();
            {
                var member = new Member();
                string MemberName;
                int CallLength = 0;
                string Resolved;
                string userInput;
                string memberId = "0";




                do
                {
                    Output();
                    userInput = Console.ReadLine();


                    if (userInput != "no" && userInput != "exit")
                    {
                        member = new Member();
                        Console.WriteLine("Please enter the first name of your caller.");
                        member.MemberName = Console.ReadLine();
                        Console.WriteLine("Please enter the member ID for your member.");
                        member.memberId = Console.ReadLine();
                        Console.WriteLine("Please enter the length of your call in minutes.");
                        member.CallLength = int.Parse(Console.ReadLine());
                        Console.WriteLine("Was the issue resolved?");
                        member.Resolved = Console.ReadLine();
                        memberList.Add(member);

                    }
                    else if (userInput != "exit")

                    {
                        int counter = 1;
                        foreach (Member m in memberList)
                        {
                            Console.WriteLine(counter.ToString() + ", " + m.MemberName + " " + m.memberId + " " + m.CallLength + " call resolved: " + m.Resolved + " .");

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
                csv.WriteRecords(memberList);
            }

        }
        public static List<Member> ReadMembers()
        {

            var CSVConfig = new CsvConfiguration(CultureInfo.CurrentCulture);
            using (var streamReader = File.OpenText("MemberList.csv"))
            using (var csvReader = new CsvReader(streamReader, CSVConfig))
            {
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
                        string Id;
                        string Resolved;
                        int calllength;
                        csvReader.TryGetField<string>(0, out Name);
                        csvReader.TryGetField<string>(1, out Id);
                        csvReader.TryGetField<string>(2, out Resolved);
                        csvReader.TryGetField<int>(3, out calllength);
                        member.MemberName = Name;
                        member.memberId = Id;
                        member.Resolved = Resolved;
                        member.CallLength = calllength;

                        memberList.Add(member);

                    }



                }
                streamReader.Close();
                csvReader.Dispose();
                return memberList;


            }







        }

        public static void Output()
        {
            Console.WriteLine("Do you need to document a new call? Please type 'yes' or 'no'. OR Type exit to finish.");
        }




    }














}

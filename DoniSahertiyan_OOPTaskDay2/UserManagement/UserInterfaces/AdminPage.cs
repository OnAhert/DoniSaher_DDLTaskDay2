using Services.Dtos;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace UserManagement.UserInterfaces
{
    public static class AdminPage
    {
        private static LoginService loginService = LoginService.Instance;
        private static MemberService memberService = MemberService.Instance;
        private static LoginInfo loginInfo = loginService.GetLoginInfo();

        private static List<string> options = new List<string>()
        {
            "Add member account",
            "Disable member account",
            "Update member password", //Update member password interface
            "Delete member account", //Delete member account interface
            "Logout"
        };

        public static void Start()
        {
            while (loginInfo.IsLoggedIn)
            {
                var choice = Helpers.GetChoice(options);

                if (choice == options.Count)
                {
                    loginService.Logout();
                    Console.WriteLine("You've logged out.");
                    continue;
                }

                if (choice == 1)
                {
                    try
                    {
                        Console.WriteLine("Enter member username:");
                        var username = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Enter member password:");
                        var password = Console.ReadLine();

                        if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                            continue;

                        memberService.AddNewMember(username, password);
                        Console.WriteLine("\nSuccess to add member");
                    }
                    catch(Exception ex)
                    {
                        continue;
                    }
                }

                if (choice == 2)
                {
                    try
                    {
                        Console.WriteLine("Enter member username:");
                        var username = Console.ReadLine();
                        Console.WriteLine();
                        
                        memberService.DisableMember(username);
                        Console.WriteLine("\nYour password was disabled");
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
                if (choice == 3)
                {
                    try
                    {
                        Console.WriteLine("Enter member username:");
                        var username = Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Enter new member password:");
                        var password = Console.ReadLine();

                        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                            continue;

                        memberService.UpdatePassword(username, password);
                        Console.WriteLine("\nYour password was updated");
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
                if (choice == 4)
                {
                    try
                    {
                        Console.WriteLine("Enter member username:");
                        var username = Console.ReadLine();
                        Console.WriteLine();

                        memberService.DeleteMember(username);
                        Console.WriteLine($"Member {username} was deleted");
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
            }
        }
    }
}

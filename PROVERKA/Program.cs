using PROVERKA.Models;
using System;

namespace PROVERKA
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            //Application.Run(new QueueForm(new FacadeDB()));
            

            //Application.Run(new LoginForm());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ������ �������� ��
            using (var db = new LoginForm())
            {
                // �������� ����� �������� ���������� ������������
                db.EnsureInitialUserCreated();
            }

            // ��������� ������� �����
            Application.Run(new LoginForm());

            //Console.WriteLine(initialized ? "���� ����������������" : "������������� �� �����������");
        }
    }
}
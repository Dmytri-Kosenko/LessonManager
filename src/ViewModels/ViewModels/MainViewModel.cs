using Models;
using Models.DataProviders.SqlServer;
using Models.DataProviders.SqlServer.Repositories;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.Commands;
using ViewModel.Commands.AsyncCommands;

namespace ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private bool _isBusy;
        public IErrorHandler ErrorHandler { private get; set; }
        private string _newStudent;
        public string NewStudent
        {
            private get => _newStudent;
            set
            {
                set(ref _newStudent, value);
            }
        }

        private const string  PatternName = @"^[А-ЯЁ][а-яё]";

        public AsyncCommand AsyncStudentCreateCommand { get; }
        public ObservableCollection<Student>? Students { get; set; } = null!;
        private readonly SqlSerDbContext context;
        private readonly DataManager data;
        public MainViewModel()
        {
            context = new SqlSerDbContext();
            data = new DataManager(new SqlServerStudents(context), new SqlServerCourses(context));
            Students = new ObservableCollection<Student>(data.StudentsRep.Items);

            AsyncStudentCreateCommand = new AsyncCommand(CreateStudentAsync, CanExecuteCreateStudent, ErrorHandler);

        }

        private bool CanExecuteCreateStudent(string? student)
        {
            if (_isBusy) return false;
            var res = student?.Trim();
            if (string.IsNullOrWhiteSpace(res)) return false;
            return Regex.IsMatch(res, PatternName);
        }

        private bool CanExecuteCreateStudent() => CanExecuteCreateStudent(NewStudent);
        private Task CreateStudentAsync(CancellationToken? arg)
        {
            try
            {
                _isBusy = true;

            }
            finally
            {
                _isBusy = false;
            }
        }
        #region Свойства
        #endregion
    }
}

﻿using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MonkeyHubApp.Models;
using MonkeyHubApp.Services;
using Xamarin.Forms;

namespace MonkeyHubApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Tag> Tags { get; }

        public Command AboutCommand { get; }

        public Command<Tag> ShowCategoriaCommand { get; }

        public MainViewModel()
        {
            Tags = new ObservableCollection<Tag>();
            AboutCommand = new Command(ExecuteAboutCommand);
            ShowCategoriaCommand = new Command<Tag>(ExecuteShowCategoriaCommand);
        }

        private async void ExecuteShowCategoriaCommand(Tag tag)
        {
            await PushAsync<CategoriaPage>(tag);
        }

        private async void ExecuteAboutCommand()
        {
            await PushAsync<AboutPage>();
        }

        public async Task LoadAsync()
        {
            var monkeyHubApiService = new MonkeyHubApiService();
            var tags = await monkeyHubApiService.GetTagsAsync();

            Tags.Clear();
            foreach (var tag in tags)
            {
                Tags.Add(tag);
            }
        }
    }
}

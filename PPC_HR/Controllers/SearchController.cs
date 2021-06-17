
using PPC_HR.DataAccess;
using PPC_HR.Models;
using PPC_HR.Views;
using System;
using System.Collections.Generic;


namespace PPC_HR.Controllers
{
    public class SearchController : IPersonPreviewController
    {
        DataReceiveService dataService = new DataReceiveService();

        private readonly IPersonPreviewModel _model;

        public SearchController(string input)
        {
            _model = new PersonPreviewModel(dataService.SearchEmpl(input));
        }

        public List<PersonPreviewView> loadPreviews()
        {
            List<PersonPreviewView> list = new List<PersonPreviewView>();
            foreach (PersonPreview preview in _model.PersonPreviews)
            {
                list.Add(new PersonPreviewView(this, _model));
            }

            return list;
        }

    }
}

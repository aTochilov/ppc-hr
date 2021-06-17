using PPC_HR.DataAccess;
using PPC_HR.Models;
using PPC_HR.Views;
using System;
using System.Collections.Generic;


namespace PPC_HR.Controllers
{
    public interface IPersonPreviewController
    {
        List<PersonPreviewView> loadPreviews();
    }
    public class PersonPreviewController : IPersonPreviewController
    {
        private readonly IPersonPreviewModel _model;


        public PersonPreviewController(IPersonPreviewModel previewModel)
        {
            if(previewModel == null) throw new ArgumentNullException("previewModel");
            _model = previewModel;
        }

        public List<PersonPreviewView> loadPreviews()
        {
            List<PersonPreviewView> list = new List<PersonPreviewView>();
            foreach(PersonPreview preview in _model.PersonPreviews)
            {
                list.Add( new PersonPreviewView(this, _model));
            }
            
            return list;
        }

        public void update(PersonPreview personPreview)
        {
            _model.updatePreview(personPreview);
        }
    }
}

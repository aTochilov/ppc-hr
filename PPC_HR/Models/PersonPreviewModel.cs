using PPC_HR.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPC_HR.Models
{
    public interface IPersonPreviewModel
    {
        List<PersonPreview> PersonPreviews { get; set; }
        event EventHandler<PersonPreviewEventArgs> PreviewUpdated;
        PersonPreview GetNextPreview();
        void updatePreview(PersonPreview preview);
    }
    public class PersonPreviewModel : IPersonPreviewModel
    {
        public List<PersonPreview> PersonPreviews { get; set; }
        public event EventHandler<PersonPreviewEventArgs> PreviewUpdated = delegate { };
        private PersonPreview currItem;

        public PersonPreviewModel()
        {
            PersonPreviews = new DataReceiveService().GetPreviews();
        }

        public PersonPreviewModel(List<short> IdList)
        {
            PersonPreviews = new DataReceiveService().GetPreviews(IdList);
        }

        private void RaisePreviewUpdated(PersonPreview personPreview)
        {
            PreviewUpdated(this, new PersonPreviewEventArgs(personPreview));
        }

        public PersonPreview GetNextPreview()
        {
            if(currItem == null)
            {
                currItem = PersonPreviews.FirstOrDefault();
                return currItem;
            }
            var nextItem = PersonPreviews.SkipWhile(p => p != currItem).Skip(1).First();
            currItem = nextItem;
            return currItem;
        }

        public void updatePreview(PersonPreview personPreview)
        {
            PersonPreview selectedPersonPreview
                = PersonPreviews.Where(p => p.id == personPreview.id)
                      .FirstOrDefault() as PersonPreview;
            selectedPersonPreview.fullname = personPreview.fullname;
            selectedPersonPreview.position = personPreview.position;
            selectedPersonPreview.phone = personPreview.phone;
            RaisePreviewUpdated(selectedPersonPreview);
        }
    }

    public class PersonPreviewEventArgs : EventArgs
    {
        public PersonPreview PersonPreview { get; set; }

        public PersonPreviewEventArgs(PersonPreview personPreview)
        {
            PersonPreview = PersonPreview;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseCore.Domain.SeedWork;
using DatabaseCore.Domain.Events;

namespace DatabaseCore.Domain.Questions
{
    public class QuestionStandard : Entity, IAggregateRoot
    {
        public Guid Id { get; }
        public string English { get; set; }
        public string Phonetic { get; set; }
        public string MeaningEnglish { get; set; }
        public string MeaningVietNam { get; set; }
        public string Note { get; set; }
        public bool IsDeleted { get; set; }
        public bool Added { get; set; }
        public DateTime created_on { get; set; }
        public string Audio { get; set; }
        public int UserId { get; set; }

        public void AddNote(string noteForQuestion)
        {
            if (!string.IsNullOrEmpty(noteForQuestion))
            {
                Note = Note + ", " + noteForQuestion;
                AddDomainEvent(new ChangeNoteQuestionStanDomainEvent(Id, noteForQuestion));
            }
        }
    }
}


using Hola.Core.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Vocap.Domain.Events;
using Vocap.Domain.Exceptions;
using Vocap.Domain.SeekWork;

namespace Vocap.Domain.AggregatesModel.VocabularyAggreate;


public class Vocabulary : Entity, IAggregateRoot
{
    [Required]
    public VietnamMeaning VietnamMeaning { get; private set; }

    public CamVocabulary CamVocabulary { get; set; }

    public string Definetion { get; set; }

    public string DaftWord { get; private set; }

    public WorkFlow WorkFlowOfVocabulary { get; set; }



    /////////////////////
    ///////CONSTRUTOR 
    ////////////////////

    public Vocabulary() { }

    public Vocabulary(CamVocabulary camvcblr, string desc) : this()
    {
        Definetion = desc;
        this.DaftWord = camvcblr.DaftWord;
        CamVocabulary = camvcblr;
    }

    public async void UpdateWorkFromDiction()
    {

        var isSuccess = await CamVocabulary.GetVocabularyFromCamDictionary(this.DaftWord);
        if (isSuccess == true)
        {
            // get from dic success;
            WorkFlowOfVocabulary = WorkFlow.ADDED;
            // add event that update success;
            AddDomainEvent(new AddEnglishVocabularyDomainEvent(DaftWord));
        }
        else
        {

        }
    }

}

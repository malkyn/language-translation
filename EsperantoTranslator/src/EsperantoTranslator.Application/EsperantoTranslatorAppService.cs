using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EsperantoTranslator.Localization;
using Volo.Abp.Application.Services;

namespace EsperantoTranslator;

/* Inherit your application services from this class.
 */
public abstract class EsperantoTranslatorAppService : ApplicationService
{
    protected EsperantoTranslatorAppService()
    {
        LocalizationResource = typeof(EsperantoTranslatorResource);
    }

    public List<string> ReadSentences(string filePath)
    {
        List<string> sentences = new List<string>();

        using (StreamReader reader = new StreamReader(filePath))
        {
            string s;
            while ((s = reader.ReadLine()) != null)
            {                               
                sentences.Add(s.Trim());
            }
        }

        return sentences;
    }
    //Comentário para subir nada no git.

    public static
        Tuple<List<List<int>>, List<List<int>>, Dictionary<string, int>, Dictionary<int, string>, List<string>, Dictionary<string, int>, Dictionary<int, string>, Tuple<List<string>>> CreateDataset(List<string> ptbrSentences,
            List<string> eoSentences)
    {
        var ptbrVocabDict = ptbrSentences.SelectMany(sentence => sentence.Split())
            .Select(word => word.Trim() + ",.\" ;:)(][?!")
            .GroupBy(word => word)
            .ToDictionary(group => group.Key, group => group.Count());

        var eoVocabDict = ptbrSentences.SelectMany(sentence => sentence.Split())
            .Select(word => word.Trim() + ",.\" ;:)(][?!")
            .GroupBy(word => word)
            .ToDictionary(group => group.Key, group => group.Count());

        var ptbrVocab = ptbrVocabDict.OrderByDescending(kv => kv.Value)
            .Select(kv => kv.Key)
            .ToList();

        var eoVocab = eoVocabDict.OrderByDescending(kv => kv.Value)
            .Select(kv => kv.Key)
            .ToList();

        ptbrVocab = ptbrVocab.Take(20000).ToList();
        eoVocab = eoVocab.Take(30000).ToList();

        int startIdx = 2;

        var ptbrWord2Idx = ptbrVocab.Select((word, idx) => (word, idx))
            .ToDictionary(tuple => tuple.word, tuple => tuple.idx + startIdx);

        ptbrWord2Idx["<ukn>"] = 0;
        ptbrWord2Idx["<pad>"] = 1;
        
        var ptbrIdx2Word = ptbrWord2Idx.ToDictionary(kv => kv.Value, kv => kv.Key);
        
        startIdx = 4;
        var eoWord2Idx = eoVocab.Select((word, idx) => (word, idx))
            .ToDictionary(tuple => tuple.word, tuple => tuple.idx);
        
        eoWord2Idx["<ukn>"] = 0;
        eoWord2Idx["<go>"] = 1;
        eoWord2Idx["<eos>"] = 2;
        eoWord2Idx["<pad>"] = 3;

        var eoIdx2Word = eoWord2Idx.ToDictionary(kv => kv.Value, kv => kv.Key);

        var x = ptbrSentences.Select(sentence => sentence.Split()
            .Select(word => ptbrWord2Idx.GetValueOrDefault(word.Trim() + ",.\" ;:)(][?!", 0))
            .ToList());
        
        var y = eoSentences.Select(sentence => sentence.Split()
            .Select(word => eoWord2Idx.GetValueOrDefault(word.Trim() + ",.\" ;:)(][?!", 0))
            .ToList());

        List<List<int>> X = new List<List<int>>();
        List<List<int>> Y = new List<List<int>>();

        for (int i = 0; i < x.Count(); i++)
        {
            int n1 = x.ToList()[i].Count();
            int n2 = y.ToList()[i].Count();
            int n = n1 < n2 ? n1 : n2;

            if (Math.Abs(n1 - n2) <= 0.3 * n && n1 <= 15 && n2 <= 15)
            {
                X.Add(x.ToList()[i]);
                Y.Add(y.ToList()[i]);
            }
        }
        return Tuple.Create(X, Y, ptbrWord2Idx, ptbrIdx2Word, ptbrVocab, eoWord2Idx, eoIdx2Word, eoVocab);
    }
}
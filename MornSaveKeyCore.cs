using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UniRx;

[assembly: InternalsVisibleTo("MornArbor")]
namespace MornLib
{
    public static class MornSaveKeyCore<TValue>
    {
        private static readonly Dictionary<string, Subject<TValue>> _subjectDict = new();

        private static Subject<TValue> GetOrCreateSubject(string key)
        {
            if (!_subjectDict.ContainsKey(key) || _subjectDict[key] == null)
            {
                _subjectDict[key] = new Subject<TValue>();
            }

            return _subjectDict[key];
        }

        internal static void OnNext(string key, TValue value)
        {
            GetOrCreateSubject(key).OnNext(value);
        }

        internal static IObservable<TValue> GetObservable(string key)
        {
            return GetOrCreateSubject(key);
        }
    }
}
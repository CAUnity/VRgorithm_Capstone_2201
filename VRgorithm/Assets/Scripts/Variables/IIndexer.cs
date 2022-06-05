
using UnityEngine;


public interface IIndexer {
    IntVariable this[int index] {
        get;
        set;
    }
}

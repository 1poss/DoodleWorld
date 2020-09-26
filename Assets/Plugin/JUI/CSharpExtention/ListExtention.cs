using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace JackUtil {

    public static class ListExtention {

        static Random random;
        public static List<T> Shuffle<T>(this List<T> _list) {
            
            if (random == null) random = new Random();

            for (int i = 0; i < _list.Count; i += 1) {

                T _cur = _list[i];

                int _rdIndex = random.Next(_list.Count);

                _list[i] = _list[_rdIndex];

                _list[_rdIndex] = _cur;

            }

            return _list;

        }

        public static T Pop<T>(this List<T> _list) {
            T t = _list.Last();
            int index = _list.Count - 1;
            _list.RemoveAt(index);
            return t;
        }

    }

}
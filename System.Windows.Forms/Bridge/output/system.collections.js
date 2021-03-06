/**
 * @version 1.0.0.0
 * @copyright Copyright ©  2017
 * @compiler Bridge.NET 15.7.0
 */
Bridge.assembly("System.Collections", function ($asm, globals) {
    "use strict";

    Bridge.define("System.Collections.ArrayList", {
        inherits: [System.Collections.IList,System.Collections.ICollection,System.Collections.IEnumerable,System.ICloneable],
        statics: {
            _defaultCapacity: 4,
            emptyArray: null,
            config: {
                init: function () {
                    this.emptyArray = System.EmptyArray$1(Object).value;
                }
            },
            adapter: function (list) {
                if (list == null) {
                    throw new System.ArgumentNullException("list");
                }
                return new System.Collections.ArrayList.IListWrapper(list);
            },
            fixedSize: function (list) {
                if (list == null) {
                    throw new System.ArgumentNullException("list");
                }
                return new System.Collections.ArrayList.FixedSizeArrayList(list);
            },
            fixedSize$1: function (list) {
                if (list == null) {
                    throw new System.ArgumentNullException("list");
                }
                return new System.Collections.ArrayList.FixedSizeList(list);
            },
            readOnly: function (list) {
                if (list == null) {
                    throw new System.ArgumentNullException("list");
                }
                return new System.Collections.ArrayList.ReadOnlyArrayList(list);
            },
            readOnly$1: function (list) {
                if (list == null) {
                    throw new System.ArgumentNullException("list");
                }
                return new System.Collections.ArrayList.ReadOnlyList(list);
            },
            repeat: function (value, count) {
                if (count < 0) {
                    throw new System.ArgumentOutOfRangeException("count", ("ArgumentOutOfRange_NeedNonNegNum"));
                }
                var list = new System.Collections.ArrayList.$ctor3((count > 4) ? count : 4);
                for (var i = 0; i < count; i = (i + 1) | 0) {
                    list.add(value);
                }
                return list;
            },
            synchronized: function (list) {
                if (list == null) {
                    throw new System.ArgumentNullException("list");
                }
                return new System.Collections.ArrayList.SyncArrayList(list);
            },
            synchronized$1: function (list) {
                if (list == null) {
                    throw new System.ArgumentNullException("list");
                }
                return new System.Collections.ArrayList.SyncIList(list);
            }
        },
        _items: null,
        _size: 0,
        _syncRoot: null,
        _version: 0,
        config: {
            alias: [
            "add", "System$Collections$IList$add",
            "clear", "System$Collections$IList$clear",
            "clone", "System$ICloneable$clone",
            "contains", "System$Collections$IList$contains",
            "copyTo", "System$Collections$ICollection$copyTo",
            "getEnumerator", "System$Collections$IEnumerable$getEnumerator",
            "indexOf", "System$Collections$IList$indexOf",
            "insert", "System$Collections$IList$insert",
            "remove", "System$Collections$IList$remove",
            "removeAt", "System$Collections$IList$removeAt",
            "getCount", "System$Collections$ICollection$getCount",
            "getIsReadOnly", "System$Collections$IList$getIsReadOnly",
            "getItem", "System$Collections$IList$getItem",
            "setItem", "System$Collections$IList$setItem"
            ]
        },
        ctor: function () {
            this.$initialize();
            this._items = System.Collections.ArrayList.emptyArray;
        },
        $ctor1: function (trash) {
            this.$initialize();
        },
        $ctor2: function (c) {
            this.$initialize();
            if (c == null) {
                throw new System.ArgumentNullException("c", ("ArgumentNull_Collection"));
            }
            var count = System.Array.getCount(c);
            if (count === 0) {
                this._items = System.Collections.ArrayList.emptyArray;
            } else {
                this._items = System.Array.init(count, null, Object);
                this.addRange(c);
            }
        },
        $ctor3: function (capacity) {
            this.$initialize();
            if (capacity < 0) {
                var values = System.Array.init(["capacity"], Object);
                throw new System.ArgumentOutOfRangeException("capacity", ("ArgumentOutOfRange_MustBeNonNegNum"));
            }
            if (capacity === 0) {
                this._items = System.Collections.ArrayList.emptyArray;
            } else {
                this._items = System.Array.init(capacity, null, Object);
            }
        },
        getCapacity: function () {
            return this._items.length;
        },
        setCapacity: function (value) {
            if (value < this._size) {
                throw new System.ArgumentOutOfRangeException("value", ("ArgumentOutOfRange_SmallCapacity"));
            }
            if (value !== this._items.length) {
                if (value > 0) {
                    var destinationArray = System.Array.init(value, null, Object);
                    if (this._size > 0) {
                        System.Array.copy(this._items, 0, destinationArray, 0, this._size);
                    }
                    this._items = destinationArray;
                } else {
                    this._items = System.Array.init(4, null, Object);
                }
            }
        },
        getCount: function () {
            return this._size;
        },
        getIsFixedSize: function () {
            return false;
        },
        getIsReadOnly: function () {
            return false;
        },
        getIsSynchronized: function () {
            return false;
        },
        getItem: function (index) {
            if ((index < 0) || (index >= this._size)) {
                throw new System.ArgumentOutOfRangeException("index", ("ArgumentOutOfRange_Index"));
            }
            return this._items[index];
        },
        setItem: function (index, value) {
            if ((index < 0) || (index >= this._size)) {
                throw new System.ArgumentOutOfRangeException("index", ("ArgumentOutOfRange_Index"));
            }
            this._items[index] = value;
            this._version = (this._version + 1) | 0;
        },
        getSyncRoot: function () {
            if (this._syncRoot == null) {
                System.Threading.Interlock.compareExchange(Object, Bridge.ref(this, "_syncRoot"), {  }, null);
            }
            return this._syncRoot;
        },
        add: function (value) {
            if (this._size === this._items.length) {
                this.ensureCapacity(((this._size + 1) | 0));
            }
            this._items[this._size] = value;
            this._version = (this._version + 1) | 0;
            var num = this._size;
            this._size = (num + 1) | 0;
        },
        addRange: function (c) {
            this.insertRange(this._size, c);
        },
        binarySearch$1: function (value) {
            return this.binarySearch(0, this.getCount(), value, null);
        },
        binarySearch$2: function (value, comparer) {
            return this.binarySearch(0, this.getCount(), value, comparer);
        },
        binarySearch: function (index, count, value, comparer) {
            if (index < 0) {
                throw new System.ArgumentOutOfRangeException("index", ("ArgumentOutOfRange_NeedNonNegNum"));
            }
            if (count < 0) {
                throw new System.ArgumentOutOfRangeException("count", ("ArgumentOutOfRange_NeedNonNegNum"));
            }
            if ((((this._size - index) | 0)) < count) {
                throw new System.ArgumentException(("Argument_InvalidOffLen"));
            }
            return System.Array.binarySearch(this._items, index, count, value, comparer);
        },
        clear: function () {
            if (this._size > 0) {
                System.Array.fill(this._items, null, 0, this._size);
                this._size = 0;
            }
            this._version = (this._version + 1) | 0;
        },
        clone: function () {
            var list = Bridge.merge(new System.Collections.ArrayList.$ctor3(this._size), {
                _size: this._size,
                _version: this._version
            } );
            System.Array.copy(this._items, 0, list._items, 0, this._size);
            return list;
        },
        contains: function (item) {
            if (item == null) {
                for (var j = 0; j < this._size; j = (j + 1) | 0) {
                    if (this._items[j] == null) {
                        return true;
                    }
                }
                return false;
            }
            for (var i = 0; i < this._size; i = (i + 1) | 0) {
                if ((this._items[i] != null) && Bridge.equals(this._items[i], item)) {
                    return true;
                }
            }
            return false;
        },
        copyTo$1: function (array) {
            this.copyTo(array, 0);
        },
        copyTo: function (array, arrayIndex) {
            if ((array != null) && (System.Array.getRank(array) !== 1)) {
                throw new System.ArgumentException(("Arg_RankMultiDimNotSupported"));
            }
            System.Array.copy(this._items, 0, array, arrayIndex, this._size);
        },
        copyTo$2: function (index, array, arrayIndex, count) {
            if ((((this._size - index) | 0)) < count) {
                throw new System.ArgumentException(("Argument_InvalidOffLen"));
            }
            if ((array != null) && (System.Array.getRank(array) !== 1)) {
                throw new System.ArgumentException(("Arg_RankMultiDimNotSupported"));
            }
            System.Array.copy(this._items, index, array, arrayIndex, count);
        },
        ensureCapacity: function (min) {
            if (this._items.length < min) {
                var num = (this._items.length === 0) ? 4 : (((this._items.length * 2) | 0));
                if (num > 2146435071) {
                    num = 2146435071;
                }
                if (num < min) {
                    num = min;
                }
                this.setCapacity(num);
            }
        },
        getEnumerator: function () {
            return new System.Collections.ArrayList.ArrayListEnumeratorSimple.$ctor1(this);
        },
        getEnumerator$1: function (index, count) {
            if (index < 0) {
                throw new System.ArgumentOutOfRangeException("index", ("ArgumentOutOfRange_NeedNonNegNum"));
            }
            if (count < 0) {
                throw new System.ArgumentOutOfRangeException("count", ("ArgumentOutOfRange_NeedNonNegNum"));
            }
            if ((((this._size - index) | 0)) < count) {
                throw new System.ArgumentException(("Argument_InvalidOffLen"));
            }
            return new System.Collections.ArrayList.ArrayListEnumerator.$ctor1(this, index, count);
        },
        getRange: function (index, count) {
            if ((index < 0) || (count < 0)) {
                throw new System.ArgumentOutOfRangeException((index < 0) ? "index" : "count", ("ArgumentOutOfRange_NeedNonNegNum"));
            }
            if ((((this._size - index) | 0)) < count) {
                throw new System.ArgumentException(("Argument_InvalidOffLen"));
            }
            return new System.Collections.ArrayList.Range(this, index, count);
        },
        indexOf: function (value) {
            return System.Array.indexOfT(this._items, value, 0, this._size);
        },
        indexOf$1: function (value, startIndex) {
            if (startIndex > this._size) {
                throw new System.ArgumentOutOfRangeException("startIndex", ("ArgumentOutOfRange_Index"));
            }
            return System.Array.indexOfT(this._items, value, startIndex, ((this._size - startIndex) | 0));
        },
        indexOf$2: function (value, startIndex, count) {
            if (startIndex > this._size) {
                throw new System.ArgumentOutOfRangeException("startIndex", ("ArgumentOutOfRange_Index"));
            }
            if ((count < 0) || (startIndex > (((this._size - count) | 0)))) {
                throw new System.ArgumentOutOfRangeException("count", ("ArgumentOutOfRange_Count"));
            }
            return System.Array.indexOfT(this._items, value, startIndex, count);
        },
        insert: function (index, value) {
            if ((index < 0) || (index > this._size)) {
                throw new System.ArgumentOutOfRangeException("index", ("ArgumentOutOfRange_ArrayListInsert"));
            }
            if (this._size === this._items.length) {
                this.ensureCapacity(((this._size + 1) | 0));
            }
            if (index < this._size) {
                System.Array.copy(this._items, index, this._items, ((index + 1) | 0), ((this._size - index) | 0));
            }
            this._items[index] = value;
            this._size = (this._size + 1) | 0;
            this._version = (this._version + 1) | 0;
        },
        insertRange: function (index, c) {
            if (c == null) {
                throw new System.ArgumentNullException("c", ("ArgumentNull_Collection"));
            }
            if ((index < 0) || (index > this._size)) {
                throw new System.ArgumentOutOfRangeException("index", ("ArgumentOutOfRange_Index"));
            }
            var count = System.Array.getCount(c);
            if (count > 0) {
                this.ensureCapacity(((this._size + count) | 0));
                if (index < this._size) {
                    System.Array.copy(this._items, index, this._items, ((index + count) | 0), ((this._size - index) | 0));
                }
                var array = System.Array.init(count, null, Object);
                System.Array.copyTo(c, array, 0);
                System.Array.copy(array, 0, this._items, index, array.length);
                this._size = (this._size + count) | 0;
                this._version = (this._version + 1) | 0;
            }
        },
        lastIndexOf: function (value) {
            return this.lastIndexOf$2(value, ((this._size - 1) | 0), this._size);
        },
        lastIndexOf$1: function (value, startIndex) {
            if (startIndex >= this._size) {
                throw new System.ArgumentOutOfRangeException("startIndex", ("ArgumentOutOfRange_Index"));
            }
            return this.lastIndexOf$2(value, startIndex, ((startIndex + 1) | 0));
        },
        lastIndexOf$2: function (value, startIndex, count) {
            if ((this.getCount() !== 0) && ((startIndex < 0) || (count < 0))) {
                throw new System.ArgumentOutOfRangeException((startIndex < 0) ? "startIndex" : "count", ("ArgumentOutOfRange_NeedNonNegNum"));
            }
            if (this._size === 0) {
                return -1;
            }
            if ((startIndex >= this._size) || (count > (((startIndex + 1) | 0)))) {
                throw new System.ArgumentOutOfRangeException((startIndex >= this._size) ? "startIndex" : "count", ("ArgumentOutOfRange_BiggerThanCollection"));
            }
            return System.Array.lastIndexOfT(this._items, value, startIndex, count);
        },
        remove: function (obj) {
            var index = this.indexOf(obj);
            if (index >= 0) {
                this.removeAt(index);
                return true;
            }
            return false;
        },
        removeAt: function (index) {
            if ((index < 0) || (index >= this._size)) {
                throw new System.ArgumentOutOfRangeException("index", ("ArgumentOutOfRange_Index"));
            }
            this._size = (this._size - 1) | 0;
            if (index < this._size) {
                System.Array.copy(this._items, ((index + 1) | 0), this._items, index, ((this._size - index) | 0));
            }
            this._items[this._size] = null;
            this._version = (this._version + 1) | 0;
        },
        removeRange: function (index, count) {
            if (index < 0) {
                throw new System.ArgumentOutOfRangeException("index", ("ArgumentOutOfRange_NeedNonNegNum"));
            }
            if (count < 0) {
                throw new System.ArgumentOutOfRangeException("count", ("ArgumentOutOfRange_NeedNonNegNum"));
            }
            if ((((this._size - index) | 0)) < count) {
                throw new System.ArgumentException(("Argument_InvalidOffLen"));
            }
            if (count > 0) {
                var num = this._size;
                this._size = (this._size - count) | 0;
                if (index < this._size) {
                    System.Array.copy(this._items, ((index + count) | 0), this._items, index, ((this._size - index) | 0));
                }
                while (num > this._size) {
                    this._items[((num = (num - 1) | 0))] = null;
                }
                this._version = (this._version + 1) | 0;
            }
        },
        reverse: function () {
            this.reverse$1(0, this.getCount());
        },
        reverse$1: function (index, count) {
            if (index < 0) {
                throw new System.ArgumentOutOfRangeException("index", ("ArgumentOutOfRange_NeedNonNegNum"));
            }
            if (count < 0) {
                throw new System.ArgumentOutOfRangeException("count", ("ArgumentOutOfRange_NeedNonNegNum"));
            }
            if ((((this._size - index) | 0)) < count) {
                throw new System.ArgumentException(("Argument_InvalidOffLen"));
            }
            System.Array.reverse(this._items, index, count);
            this._version = (this._version + 1) | 0;
        },
        setRange: function (index, c) {
            if (c == null) {
                throw new System.ArgumentNullException("c", ("ArgumentNull_Collection"));
            }
            var count = System.Array.getCount(c);
            if ((index < 0) || (index > (((this._size - count) | 0)))) {
                throw new System.ArgumentOutOfRangeException("index", ("ArgumentOutOfRange_Index"));
            }
            if (count > 0) {
                System.Array.copyTo(c, this._items, index);
                this._version = (this._version + 1) | 0;
            }
        },
        sort: function () {
            this.sort$2(0, this.getCount(), new (System.Collections.Generic.Comparer$1(Object))(System.Collections.Generic.Comparer$1.$default.fn));
        },
        sort$1: function (comparer) {
            this.sort$2(0, this.getCount(), comparer);
        },
        sort$2: function (index, count, comparer) {
            if (index < 0) {
                throw new System.ArgumentOutOfRangeException("index", ("ArgumentOutOfRange_NeedNonNegNum"));
            }
            if (count < 0) {
                throw new System.ArgumentOutOfRangeException("count", ("ArgumentOutOfRange_NeedNonNegNum"));
            }
            if ((((this._size - index) | 0)) < count) {
                throw new System.ArgumentException(("Argument_InvalidOffLen"));
            }
            System.Array.sort(this._items, index, count, comparer);
            this._version = (this._version + 1) | 0;
        },
        toArray$1: function () {
            var destinationArray = System.Array.init(this._size, null, Object);
            System.Array.copy(this._items, 0, destinationArray, 0, this._size);
            return destinationArray;
        },
        toArray: function (type) {
            if (type == null) {
                throw new System.ArgumentNullException("type");
            }
            var destinationArray = System.Array.init(this._size, Bridge.getDefaultValue(type), type);
            System.Array.copy(this._items, 0, destinationArray, 0, this._size);
            return destinationArray;
        },
        trimToSize: function () {
            this.setCapacity(this._size);
        }
    });

    Bridge.define("System.Collections.ArrayList.ArrayListDebugView", {
        arrayList: null,
        ctor: function (arrayList) {
            this.$initialize();
            if (arrayList == null) {
                throw new System.ArgumentNullException("arrayList");
            }
            this.arrayList = arrayList;
        },
        getItems: function () {
            return this.arrayList.toArray$1();
        }
    });

    Bridge.define("System.Collections.ArrayList.ArrayListEnumerator", {
        inherits: [System.Collections.IEnumerator,System.ICloneable],
        currentElement: null,
        endIndex: 0,
        index: 0,
        list: null,
        startIndex: 0,
        version: 0,
        config: {
            alias: [
            "clone", "System$ICloneable$clone",
            "moveNext", "System$Collections$IEnumerator$moveNext",
            "reset", "System$Collections$IEnumerator$reset",
            "getCurrent", "System$Collections$IEnumerator$getCurrent"
            ]
        },
        ctor: function () {
            this.$initialize();

        },
        $ctor1: function (list, index, count) {
            this.$initialize();
            this.list = list;
            this.startIndex = index;
            this.index = (index - 1) | 0;
            this.endIndex = (this.index + count) | 0;
            this.version = list._version;
            this.currentElement = null;
        },
        getCurrent: function () {
            if (this.index < this.startIndex) {
                throw new System.InvalidOperationException(("InvalidOperation_EnumNotStarted"));
            }
            if (this.index > this.endIndex) {
                throw new System.InvalidOperationException(("InvalidOperation_EnumEnded"));
            }
            return this.currentElement;
        },
        clone: function () {
            // #TODO MemberwiseClone                
            return Bridge.merge(new System.Collections.ArrayList.ArrayListEnumerator.ctor(), {
                currentElement: this.currentElement,
                endIndex: this.endIndex,
                index: this.index,
                list: this.list,
                startIndex: this.startIndex,
                version: this.version
            } );
        },
        moveNext: function () {
            if (this.version !== this.list._version) {
                throw new System.InvalidOperationException(("InvalidOperation_EnumFailedVersion"));
            }
            if (this.index < this.endIndex) {
                var num = (this.index + 1) | 0;
                this.index = num;
                this.currentElement = this.list.getItem(num);
                return true;
            }
            this.index = (this.endIndex + 1) | 0;
            return false;
        },
        reset: function () {
            if (this.version !== this.list._version) {
                throw new System.InvalidOperationException(("InvalidOperation_EnumFailedVersion"));
            }
            this.index = (this.startIndex - 1) | 0;
        }
    });

    Bridge.define("System.Collections.ArrayList.ArrayListEnumeratorSimple", {
        inherits: [System.Collections.IEnumerator,System.ICloneable],
        statics: {
            dummyObject: null,
            config: {
                init: function () {
                    this.dummyObject = {  };
                }
            }
        },
        currentElement: null,
        index: 0,
        isArrayList: false,
        list: null,
        version: 0,
        config: {
            alias: [
            "clone", "System$ICloneable$clone",
            "moveNext", "System$Collections$IEnumerator$moveNext",
            "reset", "System$Collections$IEnumerator$reset",
            "getCurrent", "System$Collections$IEnumerator$getCurrent"
            ]
        },
        ctor: function () {
            this.$initialize();

        },
        $ctor1: function (list) {
            this.$initialize();
            this.list = list;
            this.index = -1;
            this.version = list._version;
            this.isArrayList = Bridge.referenceEquals(Bridge.getType(list), System.Collections.ArrayList);
            this.currentElement = System.Collections.ArrayList.ArrayListEnumeratorSimple.dummyObject;
        },
        getCurrent: function () {
            var currentElement = this.currentElement;
            if (!Bridge.referenceEquals(System.Collections.ArrayList.ArrayListEnumeratorSimple.dummyObject, currentElement)) {
                return currentElement;
            }
            if (this.index === -1) {
                throw new System.InvalidOperationException(("InvalidOperation_EnumNotStarted"));
            }
            throw new System.InvalidOperationException(("InvalidOperation_EnumEnded"));
        },
        clone: function () {
            return Bridge.merge(new System.Collections.ArrayList.ArrayListEnumeratorSimple.ctor(), {
                currentElement: this.currentElement,
                index: this.index,
                isArrayList: this.isArrayList,
                list: this.list,
                version: this.version
            } );
        },
        moveNext: function () {
            var num;
            if (this.version !== this.list._version) {
                throw new System.InvalidOperationException(("InvalidOperation_EnumFailedVersion"));
            }
            if (this.isArrayList) {
                if (this.index < (((this.list._size - 1) | 0))) {
                    num = (this.index + 1) | 0;
                    this.index = num;
                    this.currentElement = this.list._items[num];
                    return true;
                }
                this.currentElement = System.Collections.ArrayList.ArrayListEnumeratorSimple.dummyObject;
                this.index = this.list._size;
                return false;
            }
            if (this.index < (((this.list.getCount() - 1) | 0))) {
                num = (this.index + 1) | 0;
                this.index = num;
                this.currentElement = this.list.getItem(num);
                return true;
            }
            this.index = this.list.getCount();
            this.currentElement = System.Collections.ArrayList.ArrayListEnumeratorSimple.dummyObject;
            return false;
        },
        reset: function () {
            if (this.version !== this.list._version) {
                throw new System.InvalidOperationException(("InvalidOperation_EnumFailedVersion"));
            }
            this.currentElement = System.Collections.ArrayList.ArrayListEnumeratorSimple.dummyObject;
            this.index = -1;
        }
    });

    Bridge.define("System.Collections.ArrayList.FixedSizeList", {
        inherits: [System.Collections.IList,System.Collections.ICollection,System.Collections.IEnumerable],
        _list: null,
        config: {
            alias: [
            "add", "System$Collections$IList$add",
            "clear", "System$Collections$IList$clear",
            "contains", "System$Collections$IList$contains",
            "copyTo", "System$Collections$ICollection$copyTo",
            "getEnumerator", "System$Collections$IEnumerable$getEnumerator",
            "indexOf", "System$Collections$IList$indexOf",
            "insert", "System$Collections$IList$insert",
            "remove", "System$Collections$IList$remove",
            "removeAt", "System$Collections$IList$removeAt",
            "getCount", "System$Collections$ICollection$getCount",
            "getIsReadOnly", "System$Collections$IList$getIsReadOnly",
            "getItem", "System$Collections$IList$getItem",
            "setItem", "System$Collections$IList$setItem"
            ]
        },
        ctor: function (l) {
            this.$initialize();
            this._list = l;
        },
        getCount: function () {
            return System.Array.getCount(this._list);
        },
        getIsFixedSize: function () {
            return true;
        },
        getIsReadOnly: function () {
            return System.Array.getIsReadOnly(this._list);
        },
        getIsSynchronized: function () {
            return true;
        },
        getItem: function (index) {
            return System.Array.getItem(this._list, index);
        },
        setItem: function (index, value) {
            System.Array.setItem(this._list, index, value);
        },
        getSyncRoot: function () {
            return false;
        },
        add: function (obj) {
            throw new System.NotSupportedException(("NotSupported_FixedSizeCollection"));
        },
        clear: function () {
            throw new System.NotSupportedException(("NotSupported_FixedSizeCollection"));
        },
        contains: function (obj) {
            return System.Array.contains(this._list, obj);
        },
        copyTo: function (array, index) {
            System.Array.copyTo(this._list, array, index);
        },
        getEnumerator: function () {
            return Bridge.getEnumerator(this._list);
        },
        indexOf: function (value) {
            return System.Array.indexOf(this._list, value, 0, null);
        },
        insert: function (index, obj) {
            throw new System.NotSupportedException(("NotSupported_FixedSizeCollection"));
        },
        remove: function (value) {
            throw new System.NotSupportedException(("NotSupported_FixedSizeCollection"));
        },
        removeAt: function (index) {
            throw new System.NotSupportedException(("NotSupported_FixedSizeCollection"));
        }
    });

    Bridge.define("System.Collections.ArrayList.IListWrapper.IListWrapperEnumWrapper", {
        inherits: [System.Collections.IEnumerator,System.ICloneable],
        _en: null,
        _firstCall: false,
        _initialCount: 0,
        _initialStartIndex: 0,
        _remaining: 0,
        config: {
            alias: [
            "clone", "System$ICloneable$clone",
            "moveNext", "System$Collections$IEnumerator$moveNext",
            "reset", "System$Collections$IEnumerator$reset",
            "getCurrent", "System$Collections$IEnumerator$getCurrent"
            ]
        },
        ctor: function () {
            this.$initialize();
        },
        $ctor1: function (listWrapper, startIndex, count) {
            this.$initialize();
            this._en = listWrapper.getEnumerator();
            this._initialStartIndex = startIndex;
            this._initialCount = count;
            while ((Bridge.identity(startIndex, (startIndex = (startIndex - 1) | 0)) > 0) && this._en.System$Collections$IEnumerator$moveNext()) {
            }
            this._remaining = count;
            this._firstCall = true;
        },
        getCurrent: function () {
            if (this._firstCall) {
                throw new System.InvalidOperationException(("InvalidOperation_EnumNotStarted"));
            }
            if (this._remaining < 0) {
                throw new System.InvalidOperationException(("InvalidOperation_EnumEnded"));
            }
            return this._en.System$Collections$IEnumerator$getCurrent();
        },
        clone: function () {
            return Bridge.merge(new System.Collections.ArrayList.IListWrapper.IListWrapperEnumWrapper.ctor(), {
                _en: Bridge.cast(Bridge.clone(Bridge.cast(this._en, System.ICloneable)), System.Collections.IEnumerator),
                _initialStartIndex: this._initialStartIndex,
                _initialCount: this._initialCount,
                _remaining: this._remaining,
                _firstCall: this._firstCall
            } );
        },
        moveNext: function () {
            var num;
            if (this._firstCall) {
                this._firstCall = false;
                num = this._remaining;
                this._remaining = (num - 1) | 0;
                return ((num > 0) && this._en.System$Collections$IEnumerator$moveNext());
            }
            if ((this._remaining >= 0) && this._en.System$Collections$IEnumerator$moveNext()) {
                num = this._remaining;
                this._remaining = (num - 1) | 0;
                return (num > 0);
            }
            return false;
        },
        reset: function () {
            this._en.System$Collections$IEnumerator$reset();
            var num = this._initialStartIndex;
            while ((Bridge.identity(num, (num = (num - 1) | 0)) > 0) && this._en.System$Collections$IEnumerator$moveNext()) {
            }
            this._remaining = this._initialCount;
            this._firstCall = true;
        }
    });

    Bridge.define("System.Collections.ArrayList.ReadOnlyList", {
        inherits: [System.Collections.IList,System.Collections.ICollection,System.Collections.IEnumerable],
        _list: null,
        config: {
            alias: [
            "add", "System$Collections$IList$add",
            "clear", "System$Collections$IList$clear",
            "contains", "System$Collections$IList$contains",
            "copyTo", "System$Collections$ICollection$copyTo",
            "getEnumerator", "System$Collections$IEnumerable$getEnumerator",
            "indexOf", "System$Collections$IList$indexOf",
            "insert", "System$Collections$IList$insert",
            "remove", "System$Collections$IList$remove",
            "removeAt", "System$Collections$IList$removeAt",
            "getCount", "System$Collections$ICollection$getCount",
            "getIsReadOnly", "System$Collections$IList$getIsReadOnly",
            "getItem", "System$Collections$IList$getItem",
            "setItem", "System$Collections$IList$setItem"
            ]
        },
        ctor: function (l) {
            this.$initialize();
            this._list = l;
        },
        getCount: function () {
            return System.Array.getCount(this._list);
        },
        getIsFixedSize: function () {
            return true;
        },
        getIsReadOnly: function () {
            return true;
        },
        getIsSynchronized: function () {
            return true;
        },
        getItem: function (index) {
            return System.Array.getItem(this._list, index);
        },
        setItem: function (index, value) {
            throw new System.NotSupportedException(("NotSupported_ReadOnlyCollection"));
        },
        getSyncRoot: function () {
            return false;
        },
        add: function (obj) {
            throw new System.NotSupportedException(("NotSupported_ReadOnlyCollection"));
        },
        clear: function () {
            throw new System.NotSupportedException(("NotSupported_ReadOnlyCollection"));
        },
        contains: function (obj) {
            return System.Array.contains(this._list, obj);
        },
        copyTo: function (array, index) {
            System.Array.copyTo(this._list, array, index);
        },
        getEnumerator: function () {
            return Bridge.getEnumerator(this._list);
        },
        indexOf: function (value) {
            return System.Array.indexOf(this._list, value, 0, null);
        },
        insert: function (index, obj) {
            throw new System.NotSupportedException(("NotSupported_ReadOnlyCollection"));
        },
        remove: function (value) {
            throw new System.NotSupportedException(("NotSupported_ReadOnlyCollection"));
        },
        removeAt: function (index) {
            throw new System.NotSupportedException(("NotSupported_ReadOnlyCollection"));
        }
    });

    Bridge.define("System.Collections.ArrayList.SyncIList", {
        inherits: [System.Collections.IList,System.Collections.ICollection,System.Collections.IEnumerable],
        _list: null,
        _root: null,
        config: {
            alias: [
            "add", "System$Collections$IList$add",
            "clear", "System$Collections$IList$clear",
            "contains", "System$Collections$IList$contains",
            "copyTo", "System$Collections$ICollection$copyTo",
            "getEnumerator", "System$Collections$IEnumerable$getEnumerator",
            "indexOf", "System$Collections$IList$indexOf",
            "insert", "System$Collections$IList$insert",
            "remove", "System$Collections$IList$remove",
            "removeAt", "System$Collections$IList$removeAt",
            "getCount", "System$Collections$ICollection$getCount",
            "getIsReadOnly", "System$Collections$IList$getIsReadOnly",
            "getItem", "System$Collections$IList$getItem",
            "setItem", "System$Collections$IList$setItem"
            ]
        },
        ctor: function (list) {
            this.$initialize();
            this._list = list;
            this._root = false;
        },
        getCount: function () {
            var obj2 = this._root;
            obj2;
            {
                return System.Array.getCount(this._list);
            }
        },
        getIsFixedSize: function () {
            return false;
        },
        getIsReadOnly: function () {
            return System.Array.getIsReadOnly(this._list);
        },
        getIsSynchronized: function () {
            return true;
        },
        getItem: function (index) {
            var obj2 = this._root;
            obj2;
            {
                return System.Array.getItem(this._list, index);
            }
        },
        setItem: function (index, value) {
            var obj2 = this._root;
            obj2;
            {
                System.Array.setItem(this._list, index, value);
            }
        },
        getSyncRoot: function () {
            return this._root;
        },
        add: function (value) {
            var obj2 = this._root;
            obj2;
            {
                System.Array.add(this._list, value);
            }
        },
        clear: function () {
            var obj2 = this._root;
            obj2;
            {
                System.Array.clear(this._list);
            }
        },
        contains: function (item) {
            var obj2 = this._root;
            obj2;
            {
                return System.Array.contains(this._list, item);
            }
        },
        copyTo: function (array, index) {
            var obj2 = this._root;
            obj2;
            {
                System.Array.copyTo(this._list, array, index);
            }
        },
        getEnumerator: function () {
            var obj2 = this._root;
            obj2;
            {
                return Bridge.getEnumerator(this._list);
            }
        },
        indexOf: function (value) {
            var obj2 = this._root;
            obj2;
            {
                return System.Array.indexOf(this._list, value, 0, null);
            }
        },
        insert: function (index, value) {
            var obj2 = this._root;
            obj2;
            {
                System.Array.insert(this._list, index, value);
            }
        },
        remove: function (value) {
            var obj2 = this._root;
            obj2;
            {
                return System.Array.remove(this._list, value);
            }
        },
        removeAt: function (index) {
            var obj2 = this._root;
            obj2;
            {
                System.Array.removeAt(this._list, index);
            }
        }
    });

    Bridge.define("System.Collections.IComparer", {
        $kind: "interface"
    });

    Bridge.define("System.Collections.ReadOnlyCollectionBase", {
        inherits: [System.Collections.ICollection,System.Collections.IEnumerable],
        list: null,
        config: {
            alias: [
            "getEnumerator", "System$Collections$IEnumerable$getEnumerator",
            "getCount", "System$Collections$ICollection$getCount"
            ]
        },
        ctor: function () {
            this.$initialize();
        },
        getCount: function () {
            return this.getInnerList().getCount();
        },
        getInnerList: function () {
            if (this.list == null) {
                this.list = new System.Collections.ArrayList.ctor();
            }
            return this.list;
        },
        getIsSynchronized: function () {
            return this.getInnerList().getIsSynchronized();
        },
        getSyncRoot: function () {
            return this.getInnerList().getSyncRoot();
        },
        getEnumerator: function () {
            return this.getInnerList().getEnumerator();
        },
        System$Collections$ICollection$copyTo: function (array, index) {
            this.getInnerList().copyTo(array, index);
        }
    });

    Bridge.define("System.Collections.ArrayList.FixedSizeArrayList", {
        inherits: [System.Collections.ArrayList],
        _list: null,
        config: {
            alias: [
            "add", "System$Collections$IList$add",
            "clear", "System$Collections$IList$clear",
            "clone", "System$ICloneable$clone",
            "contains", "System$Collections$IList$contains",
            "copyTo", "System$Collections$ICollection$copyTo",
            "getEnumerator", "System$Collections$IEnumerable$getEnumerator",
            "indexOf", "System$Collections$IList$indexOf",
            "insert", "System$Collections$IList$insert",
            "remove", "System$Collections$IList$remove",
            "removeAt", "System$Collections$IList$removeAt",
            "getCount", "System$Collections$ICollection$getCount",
            "getIsReadOnly", "System$Collections$IList$getIsReadOnly",
            "getItem", "System$Collections$IList$getItem",
            "setItem", "System$Collections$IList$setItem"
            ]
        },
        ctor: function (l) {
            this.$initialize();
            System.Collections.ArrayList.ctor.call(this);
            this._list = l;
            this._version = this._list._version;
        },
        getCapacity: function () {
            return this._list.getCapacity();
        },
        setCapacity: function (value) {
            throw new System.NotSupportedException(("NotSupported_FixedSizeCollection"));
        },
        getCount: function () {
            return this._list.getCount();
        },
        getIsFixedSize: function () {
            return true;
        },
        getIsReadOnly: function () {
            return this._list.getIsReadOnly();
        },
        getIsSynchronized: function () {
            return this._list.getIsSynchronized();
        },
        getItem: function (index) {
            return this._list.getItem(index);
        },
        setItem: function (index, value) {
            this._list.setItem(index, value);
            this._version = this._list._version;
        },
        getSyncRoot: function () {
            return this._list.getSyncRoot();
        },
        add: function (obj) {
            throw new System.NotSupportedException(("NotSupported_FixedSizeCollection"));
        },
        addRange: function (c) {
            throw new System.NotSupportedException(("NotSupported_FixedSizeCollection"));
        },
        binarySearch: function (index, count, value, comparer) {
            return this._list.binarySearch(index, count, value, comparer);
        },
        clear: function () {
            throw new System.NotSupportedException(("NotSupported_FixedSizeCollection"));
        },
        clone: function () {
            return Bridge.merge(new System.Collections.ArrayList.FixedSizeArrayList(this._list), {
                _list: Bridge.cast(this._list.clone(), System.Collections.ArrayList)
            } );
        },
        contains: function (obj) {
            return this._list.contains(obj);
        },
        copyTo: function (array, index) {
            this._list.copyTo(array, index);
        },
        copyTo$2: function (index, array, arrayIndex, count) {
            this._list.copyTo$2(index, array, arrayIndex, count);
        },
        getEnumerator: function () {
            return this._list.getEnumerator();
        },
        getEnumerator$1: function (index, count) {
            return this._list.getEnumerator$1(index, count);
        },
        getRange: function (index, count) {
            if ((index < 0) || (count < 0)) {
                throw new System.ArgumentOutOfRangeException((index < 0) ? "index" : "count", ("ArgumentOutOfRange_NeedNonNegNum"));
            }
            if ((((this.getCount() - index) | 0)) < count) {
                throw new System.ArgumentException(("Argument_InvalidOffLen"));
            }
            return new System.Collections.ArrayList.Range(this, index, count);
        },
        indexOf: function (value) {
            return this._list.indexOf(value);
        },
        indexOf$1: function (value, startIndex) {
            return this._list.indexOf$1(value, startIndex);
        },
        indexOf$2: function (value, startIndex, count) {
            return this._list.indexOf$2(value, startIndex, count);
        },
        insert: function (index, obj) {
            throw new System.NotSupportedException(("NotSupported_FixedSizeCollection"));
        },
        insertRange: function (index, c) {
            throw new System.NotSupportedException(("NotSupported_FixedSizeCollection"));
        },
        lastIndexOf: function (value) {
            return this._list.lastIndexOf(value);
        },
        lastIndexOf$1: function (value, startIndex) {
            return this._list.lastIndexOf$1(value, startIndex);
        },
        lastIndexOf$2: function (value, startIndex, count) {
            return this._list.lastIndexOf$2(value, startIndex, count);
        },
        remove: function (value) {
            throw new System.NotSupportedException(("NotSupported_FixedSizeCollection"));
        },
        removeAt: function (index) {
            throw new System.NotSupportedException(("NotSupported_FixedSizeCollection"));
        },
        removeRange: function (index, count) {
            throw new System.NotSupportedException(("NotSupported_FixedSizeCollection"));
        },
        reverse$1: function (index, count) {
            this._list.reverse$1(index, count);
            this._version = this._list._version;
        },
        setRange: function (index, c) {
            this._list.setRange(index, c);
            this._version = this._list._version;
        },
        sort$2: function (index, count, comparer) {
            this._list.sort$2(index, count, comparer);
            this._version = this._list._version;
        },
        toArray$1: function () {
            return this._list.toArray$1();
        },
        toArray: function (type) {
            return this._list.toArray(type);
        },
        trimToSize: function () {
            throw new System.NotSupportedException(("NotSupported_FixedSizeCollection"));
        }
    });

    Bridge.define("System.Collections.ArrayList.IListWrapper", {
        inherits: [System.Collections.ArrayList],
        _list: null,
        config: {
            alias: [
            "add", "System$Collections$IList$add",
            "clear", "System$Collections$IList$clear",
            "clone", "System$ICloneable$clone",
            "contains", "System$Collections$IList$contains",
            "copyTo", "System$Collections$ICollection$copyTo",
            "getEnumerator", "System$Collections$IEnumerable$getEnumerator",
            "indexOf", "System$Collections$IList$indexOf",
            "insert", "System$Collections$IList$insert",
            "remove", "System$Collections$IList$remove",
            "removeAt", "System$Collections$IList$removeAt",
            "getCount", "System$Collections$ICollection$getCount",
            "getIsReadOnly", "System$Collections$IList$getIsReadOnly",
            "getItem", "System$Collections$IList$getItem",
            "setItem", "System$Collections$IList$setItem"
            ]
        },
        ctor: function (list) {
            this.$initialize();
            System.Collections.ArrayList.ctor.call(this);
            this._list = list;
            this._version = 0;
        },
        getCapacity: function () {
            return System.Array.getCount(this._list);
        },
        setCapacity: function (value) {
            if (value < this.getCount()) {
                throw new System.ArgumentOutOfRangeException("value", ("ArgumentOutOfRange_SmallCapacity"));
            }
        },
        getCount: function () {
            return System.Array.getCount(this._list);
        },
        getIsFixedSize: function () {
            return false;
        },
        getIsReadOnly: function () {
            return System.Array.getIsReadOnly(this._list);
        },
        getIsSynchronized: function () {
            return true;
        },
        getItem: function (index) {
            return System.Array.getItem(this._list, index);
        },
        setItem: function (index, value) {
            System.Array.setItem(this._list, index, value);
            this._version = (this._version + 1) | 0;
        },
        getSyncRoot: function () {
            return false;
        },
        add: function (obj) {
            System.Array.add(this._list, obj);
            this._version = (this._version + 1) | 0;
        },
        addRange: function (c) {
            this.insertRange(this.getCount(), c);
        },
        binarySearch: function (index, count, value, comparer) {
            if ((index < 0) || (count < 0)) {
                throw new System.ArgumentOutOfRangeException((index < 0) ? "index" : "count", ("ArgumentOutOfRange_NeedNonNegNum"));
            }
            if ((((this.getCount() - index) | 0)) < count) {
                throw new System.ArgumentException(("Argument_InvalidOffLen"));
            }
            if (comparer == null) {
                comparer = new (System.Collections.Generic.Comparer$1(Object))(System.Collections.Generic.Comparer$1.$default.fn);
            }
            var num = index;
            var num2 = ((((index + count) | 0)) - 1) | 0;
            while (num <= num2) {
                var num3 = (Bridge.Int.div((((num + num2) | 0)), 2)) | 0;
                var num4 = comparer.System$Collections$Generic$IComparer$1$Object$compare(value, System.Array.getItem(this._list, num3));
                if (num4 === 0) {
                    return num3;
                }
                if (num4 < 0) {
                    num2 = (num3 - 1) | 0;
                } else {
                    num = (num3 + 1) | 0;
                }
            }
            return ~num;
        },
        clear: function () {
            System.Array.clear(this._list);
            this._version = (this._version + 1) | 0;
        },
        clone: function () {
            return new System.Collections.ArrayList.IListWrapper(this._list);
        },
        contains: function (obj) {
            return System.Array.contains(this._list, obj);
        },
        copyTo: function (array, index) {
            System.Array.copyTo(this._list, array, index);
        },
        copyTo$2: function (index, array, arrayIndex, count) {
            if (array == null) {
                throw new System.ArgumentNullException("array");
            }
            if ((index < 0) || (arrayIndex < 0)) {
                throw new System.ArgumentOutOfRangeException((index < 0) ? "index" : "arrayIndex", ("ArgumentOutOfRange_NeedNonNegNum"));
            }
            if (count < 0) {
                throw new System.ArgumentOutOfRangeException("count", ("ArgumentOutOfRange_NeedNonNegNum"));
            }
            if ((((array.length - arrayIndex) | 0)) < count) {
                throw new System.ArgumentException(("Argument_InvalidOffLen"));
            }
            if (System.Array.getRank(array) !== 1) {
                throw new System.ArgumentException(("Arg_RankMultiDimNotSupported"));
            }
            if ((((System.Array.getCount(this._list) - index) | 0)) < count) {
                throw new System.ArgumentException(("Argument_InvalidOffLen"));
            }
            for (var i = index; i < (((index + count) | 0)); i = (i + 1) | 0) {
                System.Array.set(array, System.Array.getItem(this._list, i), Bridge.identity(arrayIndex, (arrayIndex = (arrayIndex + 1) | 0)));
            }
        },
        getEnumerator: function () {
            return Bridge.getEnumerator(this._list);
        },
        getEnumerator$1: function (index, count) {
            if ((index < 0) || (count < 0)) {
                throw new System.ArgumentOutOfRangeException((index < 0) ? "index" : "count", ("ArgumentOutOfRange_NeedNonNegNum"));
            }
            if ((((System.Array.getCount(this._list) - index) | 0)) < count) {
                throw new System.ArgumentException(("Argument_InvalidOffLen"));
            }
            return new System.Collections.ArrayList.IListWrapper.IListWrapperEnumWrapper.$ctor1(this, index, count);
        },
        getRange: function (index, count) {
            if ((index < 0) || (count < 0)) {
                throw new System.ArgumentOutOfRangeException((index < 0) ? "index" : "count", ("ArgumentOutOfRange_NeedNonNegNum"));
            }
            if ((((System.Array.getCount(this._list) - index) | 0)) < count) {
                throw new System.ArgumentException(("Argument_InvalidOffLen"));
            }
            return new System.Collections.ArrayList.Range(this, index, count);
        },
        indexOf: function (value) {
            return System.Array.indexOf(this._list, value, 0, null);
        },
        indexOf$1: function (value, startIndex) {
            return this.indexOf$2(value, startIndex, ((System.Array.getCount(this._list) - startIndex) | 0));
        },
        indexOf$2: function (value, startIndex, count) {
            if ((startIndex < 0) || (startIndex > this.getCount())) {
                throw new System.ArgumentOutOfRangeException("startIndex", ("ArgumentOutOfRange_Index"));
            }
            if ((count < 0) || (startIndex > (((this.getCount() - count) | 0)))) {
                throw new System.ArgumentOutOfRangeException("count", ("ArgumentOutOfRange_Count"));
            }
            var num = (startIndex + count) | 0;
            if (value == null) {
                for (var j = startIndex; j < num; j = (j + 1) | 0) {
                    if (System.Array.getItem(this._list, j) == null) {
                        return j;
                    }
                }
                return -1;
            }
            for (var i = startIndex; i < num; i = (i + 1) | 0) {
                if ((System.Array.getItem(this._list, i) != null) && Bridge.equals(System.Array.getItem(this._list, i), value)) {
                    return i;
                }
            }
            return -1;
        },
        insert: function (index, obj) {
            System.Array.insert(this._list, index, obj);
            this._version = (this._version + 1) | 0;
        },
        insertRange: function (index, c) {
            if (c == null) {
                throw new System.ArgumentNullException("c", ("ArgumentNull_Collection"));
            }
            if ((index < 0) || (index > this.getCount())) {
                throw new System.ArgumentOutOfRangeException("index", ("ArgumentOutOfRange_Index"));
            }
            if (System.Array.getCount(c) > 0) {
                var list = Bridge.as(this._list, System.Collections.ArrayList);
                if (list != null) {
                    list.insertRange(index, c);
                } else {
                    var enumerator = Bridge.getEnumerator(c);
                    while (enumerator.System$Collections$IEnumerator$moveNext()) {
                        System.Array.insert(this._list, Bridge.identity(index, (index = (index + 1) | 0)), enumerator.System$Collections$IEnumerator$getCurrent());
                    }
                }
                this._version = (this._version + 1) | 0;
            }
        },
        lastIndexOf: function (value) {
            return this.lastIndexOf$2(value, ((System.Array.getCount(this._list) - 1) | 0), System.Array.getCount(this._list));
        },
        lastIndexOf$1: function (value, startIndex) {
            return this.lastIndexOf$2(value, startIndex, ((startIndex + 1) | 0));
        },
        lastIndexOf$2: function (value, startIndex, count) {
            if (System.Array.getCount(this._list) !== 0) {
                if ((startIndex < 0) || (startIndex >= System.Array.getCount(this._list))) {
                    throw new System.ArgumentOutOfRangeException("startIndex", ("ArgumentOutOfRange_Index"));
                }
                if ((count < 0) || (count > (((startIndex + 1) | 0)))) {
                    throw new System.ArgumentOutOfRangeException("count", ("ArgumentOutOfRange_Count"));
                }
                var num = ((((startIndex - count) | 0)) + 1) | 0;
                if (value == null) {
                    for (var j = startIndex; j >= num; j = (j - 1) | 0) {
                        if (System.Array.getItem(this._list, j) == null) {
                            return j;
                        }
                    }
                    return -1;
                }
                for (var i = startIndex; i >= num; i = (i - 1) | 0) {
                    if ((System.Array.getItem(this._list, i) != null) && Bridge.equals(System.Array.getItem(this._list, i), value)) {
                        return i;
                    }
                }
            }
            return -1;
        },
        remove: function (value) {
            var index = this.indexOf(value);
            if (index >= 0) {
                this.removeAt(index);
                return true;
            }
            return false;
        },
        removeAt: function (index) {
            System.Array.removeAt(this._list, index);
            this._version = (this._version + 1) | 0;
        },
        removeRange: function (index, count) {
            if ((index < 0) || (count < 0)) {
                throw new System.ArgumentOutOfRangeException((index < 0) ? "index" : "count", ("ArgumentOutOfRange_NeedNonNegNum"));
            }
            if ((((System.Array.getCount(this._list) - index) | 0)) < count) {
                throw new System.ArgumentException(("Argument_InvalidOffLen"));
            }
            if (count > 0) {
                this._version = (this._version + 1) | 0;
            }
            while (count > 0) {
                System.Array.removeAt(this._list, index);
                count = (count - 1) | 0;
            }
        },
        reverse$1: function (index, count) {
            if ((index < 0) || (count < 0)) {
                throw new System.ArgumentOutOfRangeException((index < 0) ? "index" : "count", ("ArgumentOutOfRange_NeedNonNegNum"));
            }
            if ((((System.Array.getCount(this._list) - index) | 0)) < count) {
                throw new System.ArgumentException(("Argument_InvalidOffLen"));
            }
            var num = index;
            var num2 = ((((index + count) | 0)) - 1) | 0;
            while (num < num2) {
                var obj2 = System.Array.getItem(this._list, num);
                System.Array.setItem(this._list, Bridge.identity(num, (num = (num + 1) | 0)), System.Array.getItem(this._list, num2));
                System.Array.setItem(this._list, Bridge.identity(num2, (num2 = (num2 - 1) | 0)), obj2);
            }
            this._version = (this._version + 1) | 0;
        },
        setRange: function (index, c) {
            if (c == null) {
                throw new System.ArgumentNullException("c", ("ArgumentNull_Collection"));
            }
            if ((index < 0) || (index > (((System.Array.getCount(this._list) - System.Array.getCount(c)) | 0)))) {
                throw new System.ArgumentOutOfRangeException("index", ("ArgumentOutOfRange_Index"));
            }
            if (System.Array.getCount(c) > 0) {
                var enumerator = Bridge.getEnumerator(c);
                while (enumerator.System$Collections$IEnumerator$moveNext()) {
                    System.Array.setItem(this._list, Bridge.identity(index, (index = (index + 1) | 0)), enumerator.System$Collections$IEnumerator$getCurrent());
                }
                this._version = (this._version + 1) | 0;
            }
        },
        sort$2: function (index, count, comparer) {
            if ((index < 0) || (count < 0)) {
                throw new System.ArgumentOutOfRangeException((index < 0) ? "index" : "count", ("ArgumentOutOfRange_NeedNonNegNum"));
            }
            if ((((System.Array.getCount(this._list) - index) | 0)) < count) {
                throw new System.ArgumentException(("Argument_InvalidOffLen"));
            }
            var array = System.Array.init(count, null, Object);
            this.copyTo$2(index, array, 0, count);
            System.Array.sort(array, 0, count, comparer);
            for (var i = 0; i < count; i = (i + 1) | 0) {
                System.Array.setItem(this._list, ((i + index) | 0), array[i]);
            }
            this._version = (this._version + 1) | 0;
        },
        toArray$1: function () {
            var array = System.Array.init(this.getCount(), null, Object);
            System.Array.copyTo(this._list, array, 0);
            return array;
        },
        toArray: function (type) {
            if (type == null) {
                throw new System.ArgumentNullException("type");
            }
            var array = System.Array.init(System.Array.getCount(this._list), Bridge.getDefaultValue(type), type);
            System.Array.copyTo(this._list, array, 0);
            return array;
        },
        trimToSize: function () {
        }
    });

    Bridge.define("System.Collections.ArrayList.Range", {
        inherits: [System.Collections.ArrayList],
        _baseIndex: 0,
        _baseList: null,
        _baseSize: 0,
        _baseVersion: 0,
        config: {
            alias: [
            "add", "System$Collections$IList$add",
            "clear", "System$Collections$IList$clear",
            "clone", "System$ICloneable$clone",
            "contains", "System$Collections$IList$contains",
            "copyTo", "System$Collections$ICollection$copyTo",
            "getEnumerator", "System$Collections$IEnumerable$getEnumerator",
            "indexOf", "System$Collections$IList$indexOf",
            "insert", "System$Collections$IList$insert",
            "removeAt", "System$Collections$IList$removeAt",
            "getCount", "System$Collections$ICollection$getCount",
            "getIsReadOnly", "System$Collections$IList$getIsReadOnly",
            "getItem", "System$Collections$IList$getItem",
            "setItem", "System$Collections$IList$setItem"
            ]
        },
        ctor: function (list, index, count) {
            this.$initialize();
            System.Collections.ArrayList.$ctor1.call(this, false);
            this._baseList = list;
            this._baseIndex = index;
            this._baseSize = count;
            this._baseVersion = list._version;
            this._version = list._version;
        },
        getCapacity: function () {
            return this._baseList.getCapacity();
        },
        setCapacity: function (value) {
            if (value < this.getCount()) {
                throw new System.ArgumentOutOfRangeException("value", ("ArgumentOutOfRange_SmallCapacity"));
            }
        },
        getCount: function () {
            this.internalUpdateRange();
            return this._baseSize;
        },
        getIsFixedSize: function () {
            return this._baseList.getIsFixedSize();
        },
        getIsReadOnly: function () {
            return this._baseList.getIsReadOnly();
        },
        getIsSynchronized: function () {
            return this._baseList.getIsSynchronized();
        },
        getItem: function (index) {
            this.internalUpdateRange();
            if ((index < 0) || (index >= this._baseSize)) {
                throw new System.ArgumentOutOfRangeException("index", ("ArgumentOutOfRange_Index"));
            }
            return this._baseList.getItem(((this._baseIndex + index) | 0));
        },
        setItem: function (index, value) {
            this.internalUpdateRange();
            if ((index < 0) || (index >= this._baseSize)) {
                throw new System.ArgumentOutOfRangeException("index", ("ArgumentOutOfRange_Index"));
            }
            this._baseList.setItem(((this._baseIndex + index) | 0), value);
            this.internalUpdateVersion();
        },
        getSyncRoot: function () {
            return this._baseList.getSyncRoot();
        },
        add: function (value) {
            this.internalUpdateRange();
            this._baseList.insert(((this._baseIndex + this._baseSize) | 0), value);
            this.internalUpdateVersion();

            this._baseSize = this._baseList.getCount();
        },
        addRange: function (c) {
            if (c == null) {
                throw new System.ArgumentNullException("c");
            }
            this.internalUpdateRange();
            var count = System.Array.getCount(c);
            if (count > 0) {
                this._baseList.insertRange(((this._baseIndex + this._baseSize) | 0), c);
                this.internalUpdateVersion();
                this._baseSize = (this._baseSize + count) | 0;
            }
        },
        binarySearch: function (index, count, value, comparer) {
            if ((index < 0) || (count < 0)) {
                throw new System.ArgumentOutOfRangeException((index < 0) ? "index" : "count", ("ArgumentOutOfRange_NeedNonNegNum"));
            }
            if ((((this._baseSize - index) | 0)) < count) {
                throw new System.ArgumentException(("Argument_InvalidOffLen"));
            }
            this.internalUpdateRange();
            var num = this._baseList.binarySearch(((this._baseIndex + index) | 0), count, value, comparer);
            if (num >= 0) {
                return (((num - this._baseIndex) | 0));
            }
            return (((num + this._baseIndex) | 0));
        },
        clear: function () {
            this.internalUpdateRange();
            if (this._baseSize !== 0) {
                this._baseList.removeRange(this._baseIndex, this._baseSize);
                this.internalUpdateVersion();
                this._baseSize = 0;
            }
        },
        clone: function () {
            this.internalUpdateRange();
            return Bridge.merge(new System.Collections.ArrayList.Range(this._baseList, this._baseIndex, this._baseSize), {
                _baseList: Bridge.cast(this._baseList.clone(), System.Collections.ArrayList)
            } );
        },
        contains: function (item) {
            this.internalUpdateRange();
            if (item == null) {
                for (var j = 0; j < this._baseSize; j = (j + 1) | 0) {
                    if (this._baseList.getItem(((this._baseIndex + j) | 0)) == null) {
                        return true;
                    }
                }
                return false;
            }
            for (var i = 0; i < this._baseSize; i = (i + 1) | 0) {
                if ((this._baseList.getItem(((this._baseIndex + i) | 0)) != null) && Bridge.equals(this._baseList.getItem(((this._baseIndex + i) | 0)), item)) {
                    return true;
                }
            }
            return false;
        },
        copyTo: function (array, index) {
            if (array == null) {
                throw new System.ArgumentNullException("array");
            }
            if (System.Array.getRank(array) !== 1) {
                throw new System.ArgumentException(("Arg_RankMultiDimNotSupported"));
            }
            if (index < 0) {
                throw new System.ArgumentOutOfRangeException("index", ("ArgumentOutOfRange_NeedNonNegNum"));
            }
            if ((((array.length - index) | 0)) < this._baseSize) {
                throw new System.ArgumentException(("Argument_InvalidOffLen"));
            }
            this.internalUpdateRange();
            this._baseList.copyTo$2(this._baseIndex, array, index, this._baseSize);
        },
        copyTo$2: function (index, array, arrayIndex, count) {
            if (array == null) {
                throw new System.ArgumentNullException("array");
            }
            if (System.Array.getRank(array) !== 1) {
                throw new System.ArgumentException(("Arg_RankMultiDimNotSupported"));
            }
            if ((index < 0) || (count < 0)) {
                throw new System.ArgumentOutOfRangeException((index < 0) ? "index" : "count", ("ArgumentOutOfRange_NeedNonNegNum"));
            }
            if ((((array.length - arrayIndex) | 0)) < count) {
                throw new System.ArgumentException(("Argument_InvalidOffLen"));
            }
            if ((((this._baseSize - index) | 0)) < count) {
                throw new System.ArgumentException(("Argument_InvalidOffLen"));
            }
            this.internalUpdateRange();
            this._baseList.copyTo$2(((this._baseIndex + index) | 0), array, arrayIndex, count);
        },
        getEnumerator: function () {
            return this.getEnumerator$1(0, this._baseSize);
        },
        getEnumerator$1: function (index, count) {
            if ((index < 0) || (count < 0)) {
                throw new System.ArgumentOutOfRangeException((index < 0) ? "index" : "count", ("ArgumentOutOfRange_NeedNonNegNum"));
            }
            if ((((this._baseSize - index) | 0)) < count) {
                throw new System.ArgumentException(("Argument_InvalidOffLen"));
            }
            this.internalUpdateRange();
            return this._baseList.getEnumerator$1(((this._baseIndex + index) | 0), count);
        },
        getRange: function (index, count) {
            if ((index < 0) || (count < 0)) {
                throw new System.ArgumentOutOfRangeException((index < 0) ? "index" : "count", ("ArgumentOutOfRange_NeedNonNegNum"));
            }
            if ((((this._baseSize - index) | 0)) < count) {
                throw new System.ArgumentException(("Argument_InvalidOffLen"));
            }
            this.internalUpdateRange();
            return new System.Collections.ArrayList.Range(this, index, count);
        },
        indexOf: function (value) {
            this.internalUpdateRange();
            var num = this._baseList.indexOf$2(value, this._baseIndex, this._baseSize);
            if (num >= 0) {
                return (((num - this._baseIndex) | 0));
            }
            return -1;
        },
        indexOf$1: function (value, startIndex) {
            if (startIndex < 0) {
                throw new System.ArgumentOutOfRangeException("startIndex", ("ArgumentOutOfRange_NeedNonNegNum"));
            }
            if (startIndex > this._baseSize) {
                throw new System.ArgumentOutOfRangeException("startIndex", ("ArgumentOutOfRange_Index"));
            }
            this.internalUpdateRange();
            var num = this._baseList.indexOf$2(value, ((this._baseIndex + startIndex) | 0), ((this._baseSize - startIndex) | 0));
            if (num >= 0) {
                return (((num - this._baseIndex) | 0));
            }
            return -1;
        },
        indexOf$2: function (value, startIndex, count) {
            if ((startIndex < 0) || (startIndex > this._baseSize)) {
                throw new System.ArgumentOutOfRangeException("startIndex", ("ArgumentOutOfRange_Index"));
            }
            if ((count < 0) || (startIndex > (((this._baseSize - count) | 0)))) {
                throw new System.ArgumentOutOfRangeException("count", ("ArgumentOutOfRange_Count"));
            }
            this.internalUpdateRange();
            var num = this._baseList.indexOf$2(value, ((this._baseIndex + startIndex) | 0), count);
            if (num >= 0) {
                return (((num - this._baseIndex) | 0));
            }
            return -1;
        },
        insert: function (index, value) {
            if ((index < 0) || (index > this._baseSize)) {
                throw new System.ArgumentOutOfRangeException("index", ("ArgumentOutOfRange_Index"));
            }
            this.internalUpdateRange();
            this._baseList.insert(((this._baseIndex + index) | 0), value);
            this.internalUpdateVersion();
            this._baseSize = (this._baseSize + 1) | 0;
        },
        insertRange: function (index, c) {
            if ((index < 0) || (index > this._baseSize)) {
                throw new System.ArgumentOutOfRangeException("index", ("ArgumentOutOfRange_Index"));
            }
            if (c == null) {
                throw new System.ArgumentNullException("c");
            }
            this.internalUpdateRange();
            var count = System.Array.getCount(c);
            if (count > 0) {
                this._baseList.insertRange(((this._baseIndex + index) | 0), c);
                this._baseSize = (this._baseSize + count) | 0;
                this.internalUpdateVersion();
            }
        },
        internalUpdateRange: function () {
            if (this._baseVersion !== this._baseList._version) {
                throw new System.InvalidOperationException(("InvalidOperation_UnderlyingArrayListChanged"));
            }
        },
        internalUpdateVersion: function () {
            this._baseVersion = (this._baseVersion + 1) | 0;
            this._version = (this._version + 1) | 0;
        },
        lastIndexOf: function (value) {
            this.internalUpdateRange();
            var num = this._baseList.lastIndexOf$2(value, (((((this._baseIndex + this._baseSize) | 0)) - 1) | 0), this._baseSize);
            if (num >= 0) {
                return (((num - this._baseIndex) | 0));
            }
            return -1;
        },
        lastIndexOf$1: function (value, startIndex) {
            return this.lastIndexOf$2(value, startIndex, ((startIndex + 1) | 0));
        },
        lastIndexOf$2: function (value, startIndex, count) {
            this.internalUpdateRange();
            if (this._baseSize !== 0) {
                if (startIndex >= this._baseSize) {
                    throw new System.ArgumentOutOfRangeException("startIndex", ("ArgumentOutOfRange_Index"));
                }
                if (startIndex < 0) {
                    throw new System.ArgumentOutOfRangeException("startIndex", ("ArgumentOutOfRange_NeedNonNegNum"));
                }
                var num = this._baseList.lastIndexOf$2(value, ((this._baseIndex + startIndex) | 0), count);
                if (num >= 0) {
                    return (((num - this._baseIndex) | 0));
                }
            }
            return -1;
        },
        removeAt: function (index) {
            if ((index < 0) || (index >= this._baseSize)) {
                throw new System.ArgumentOutOfRangeException("index", ("ArgumentOutOfRange_Index"));
            }
            this.internalUpdateRange();
            this._baseList.removeAt(((this._baseIndex + index) | 0));
            this.internalUpdateVersion();
            this._baseSize = (this._baseSize - 1) | 0;
        },
        removeRange: function (index, count) {
            if ((index < 0) || (count < 0)) {
                throw new System.ArgumentOutOfRangeException((index < 0) ? "index" : "count", ("ArgumentOutOfRange_NeedNonNegNum"));
            }
            if ((((this._baseSize - index) | 0)) < count) {
                throw new System.ArgumentException(("Argument_InvalidOffLen"));
            }
            this.internalUpdateRange();
            if (count > 0) {
                this._baseList.removeRange(((this._baseIndex + index) | 0), count);
                this.internalUpdateVersion();
                this._baseSize = (this._baseSize - count) | 0;
            }
        },
        reverse$1: function (index, count) {
            if ((index < 0) || (count < 0)) {
                throw new System.ArgumentOutOfRangeException((index < 0) ? "index" : "count", ("ArgumentOutOfRange_NeedNonNegNum"));
            }
            if ((((this._baseSize - index) | 0)) < count) {
                throw new System.ArgumentException(("Argument_InvalidOffLen"));
            }
            this.internalUpdateRange();
            this._baseList.reverse$1(((this._baseIndex + index) | 0), count);
            this.internalUpdateVersion();
        },
        setRange: function (index, c) {
            this.internalUpdateRange();
            if ((index < 0) || (index >= this._baseSize)) {
                throw new System.ArgumentOutOfRangeException("index", ("ArgumentOutOfRange_Index"));
            }
            this._baseList.setRange(((this._baseIndex + index) | 0), c);
            if (System.Array.getCount(c) > 0) {
                this.internalUpdateVersion();
            }
        },
        sort$2: function (index, count, comparer) {
            if ((index < 0) || (count < 0)) {
                throw new System.ArgumentOutOfRangeException((index < 0) ? "index" : "count", ("ArgumentOutOfRange_NeedNonNegNum"));
            }
            if ((((this._baseSize - index) | 0)) < count) {
                throw new System.ArgumentException(("Argument_InvalidOffLen"));
            }
            this.internalUpdateRange();
            this._baseList.sort$2(((this._baseIndex + index) | 0), count, comparer);
            this.internalUpdateVersion();
        },
        toArray$1: function () {
            this.internalUpdateRange();
            var destinationArray = System.Array.init(this._baseSize, null, Object);
            System.Array.copy(this._baseList._items, this._baseIndex, destinationArray, 0, this._baseSize);
            return destinationArray;
        },
        toArray: function (type) {
            if (type == null) {
                throw new System.ArgumentNullException("type");
            }
            this.internalUpdateRange();
            var array = System.Array.init(this._baseSize, Bridge.getDefaultValue(type), type);
            this._baseList.copyTo$2(this._baseIndex, array, 0, this._baseSize);
            return array;
        },
        trimToSize: function () {
            throw new System.NotSupportedException(("NotSupported_RangeCollection"));
        }
    });

    Bridge.define("System.Collections.ArrayList.ReadOnlyArrayList", {
        inherits: [System.Collections.ArrayList],
        _list: null,
        config: {
            alias: [
            "add", "System$Collections$IList$add",
            "clear", "System$Collections$IList$clear",
            "clone", "System$ICloneable$clone",
            "contains", "System$Collections$IList$contains",
            "copyTo", "System$Collections$ICollection$copyTo",
            "getEnumerator", "System$Collections$IEnumerable$getEnumerator",
            "indexOf", "System$Collections$IList$indexOf",
            "insert", "System$Collections$IList$insert",
            "remove", "System$Collections$IList$remove",
            "removeAt", "System$Collections$IList$removeAt",
            "getCount", "System$Collections$ICollection$getCount",
            "getIsReadOnly", "System$Collections$IList$getIsReadOnly",
            "getItem", "System$Collections$IList$getItem",
            "setItem", "System$Collections$IList$setItem"
            ]
        },
        ctor: function (l) {
            this.$initialize();
            System.Collections.ArrayList.ctor.call(this);
            this._list = l;
        },
        getCapacity: function () {
            return this._list.getCapacity();
        },
        setCapacity: function (value) {
            throw new System.NotSupportedException(("NotSupported_ReadOnlyCollection"));
        },
        getCount: function () {
            return this._list.getCount();
        },
        getIsFixedSize: function () {
            return true;
        },
        getIsReadOnly: function () {
            return true;
        },
        getIsSynchronized: function () {
            return this._list.getIsSynchronized();
        },
        getItem: function (index) {
            return this._list.getItem(index);
        },
        setItem: function (index, value) {
            throw new System.NotSupportedException(("NotSupported_ReadOnlyCollection"));
        },
        getSyncRoot: function () {
            return this._list.getSyncRoot();
        },
        add: function (obj) {
            throw new System.NotSupportedException(("NotSupported_ReadOnlyCollection"));
        },
        addRange: function (c) {
            throw new System.NotSupportedException(("NotSupported_ReadOnlyCollection"));
        },
        binarySearch: function (index, count, value, comparer) {
            return this._list.binarySearch(index, count, value, comparer);
        },
        clear: function () {
            throw new System.NotSupportedException(("NotSupported_ReadOnlyCollection"));
        },
        clone: function () {
            return Bridge.merge(new System.Collections.ArrayList.ReadOnlyArrayList(this._list), {
                _list: Bridge.cast(this._list.clone(), System.Collections.ArrayList)
            } );
        },
        contains: function (obj) {
            return this._list.contains(obj);
        },
        copyTo: function (array, index) {
            this._list.copyTo(array, index);
        },
        copyTo$2: function (index, array, arrayIndex, count) {
            this._list.copyTo$2(index, array, arrayIndex, count);
        },
        getEnumerator: function () {
            return this._list.getEnumerator();
        },
        getEnumerator$1: function (index, count) {
            return this._list.getEnumerator$1(index, count);
        },
        getRange: function (index, count) {
            if ((index < 0) || (count < 0)) {
                throw new System.ArgumentOutOfRangeException((index < 0) ? "index" : "count", ("ArgumentOutOfRange_NeedNonNegNum"));
            }
            if ((((this.getCount() - index) | 0)) < count) {
                throw new System.ArgumentException(("Argument_InvalidOffLen"));
            }
            return new System.Collections.ArrayList.Range(this, index, count);
        },
        indexOf: function (value) {
            return this._list.indexOf(value);
        },
        indexOf$1: function (value, startIndex) {
            return this._list.indexOf$1(value, startIndex);
        },
        indexOf$2: function (value, startIndex, count) {
            return this._list.indexOf$2(value, startIndex, count);
        },
        insert: function (index, obj) {
            throw new System.NotSupportedException(("NotSupported_ReadOnlyCollection"));
        },
        insertRange: function (index, c) {
            throw new System.NotSupportedException(("NotSupported_ReadOnlyCollection"));
        },
        lastIndexOf: function (value) {
            return this._list.lastIndexOf(value);
        },
        lastIndexOf$1: function (value, startIndex) {
            return this._list.lastIndexOf$1(value, startIndex);
        },
        lastIndexOf$2: function (value, startIndex, count) {
            return this._list.lastIndexOf$2(value, startIndex, count);
        },
        remove: function (value) {
            throw new System.NotSupportedException(("NotSupported_ReadOnlyCollection"));
        },
        removeAt: function (index) {
            throw new System.NotSupportedException(("NotSupported_ReadOnlyCollection"));
        },
        removeRange: function (index, count) {
            throw new System.NotSupportedException(("NotSupported_ReadOnlyCollection"));
        },
        reverse$1: function (index, count) {
            throw new System.NotSupportedException(("NotSupported_ReadOnlyCollection"));
        },
        setRange: function (index, c) {
            throw new System.NotSupportedException(("NotSupported_ReadOnlyCollection"));
        },
        sort$2: function (index, count, comparer) {
            throw new System.NotSupportedException(("NotSupported_ReadOnlyCollection"));
        },
        toArray$1: function () {
            return this._list.toArray$1();
        },
        toArray: function (type) {
            return this._list.toArray(type);
        },
        trimToSize: function () {
            throw new System.NotSupportedException(("NotSupported_ReadOnlyCollection"));
        }
    });

    Bridge.define("System.Collections.ArrayList.SyncArrayList", {
        inherits: [System.Collections.ArrayList],
        _list: null,
        _root: null,
        config: {
            alias: [
            "add", "System$Collections$IList$add",
            "clear", "System$Collections$IList$clear",
            "clone", "System$ICloneable$clone",
            "contains", "System$Collections$IList$contains",
            "copyTo", "System$Collections$ICollection$copyTo",
            "getEnumerator", "System$Collections$IEnumerable$getEnumerator",
            "indexOf", "System$Collections$IList$indexOf",
            "insert", "System$Collections$IList$insert",
            "remove", "System$Collections$IList$remove",
            "removeAt", "System$Collections$IList$removeAt",
            "getCount", "System$Collections$ICollection$getCount",
            "getIsReadOnly", "System$Collections$IList$getIsReadOnly",
            "getItem", "System$Collections$IList$getItem",
            "setItem", "System$Collections$IList$setItem"
            ]
        },
        ctor: function (list) {
            this.$initialize();
            System.Collections.ArrayList.$ctor1.call(this, false);
            this._list = list;
            this._root = list.getSyncRoot();
        },
        getCapacity: function () {
            var obj2 = this._root;
            obj2;
            {
                return this._list.getCapacity();
            }
        },
        setCapacity: function (value) {
            var obj2 = this._root;
            obj2;
            {
                this._list.setCapacity(value);
            }
        },
        getCount: function () {
            var obj2 = this._root;
            obj2;
            {
                return this._list.getCount();
            }
        },
        getIsFixedSize: function () {
            return this._list.getIsFixedSize();
        },
        getIsReadOnly: function () {
            return this._list.getIsReadOnly();
        },
        getIsSynchronized: function () {
            return true;
        },
        getItem: function (index) {
            var obj2 = this._root;
            obj2;
            {
                return this._list.getItem(index);
            }
        },
        setItem: function (index, value) {
            var obj2 = this._root;
            obj2;
            {
                this._list.setItem(index, value);
            }
        },
        getSyncRoot: function () {
            return this._root;
        },
        add: function (value) {
            var obj2 = this._root;
            obj2;
            {
                this._list.add(value);
            }
        },
        addRange: function (c) {
            var obj2 = this._root;
            obj2;
            {
                this._list.addRange(c);
            }
        },
        binarySearch$1: function (value) {
            var obj2 = this._root;
            obj2;
            {
                return this._list.binarySearch$1(value);
            }
        },
        binarySearch$2: function (value, comparer) {
            var obj2 = this._root;
            obj2;
            {
                return this._list.binarySearch$2(value, comparer);
            }
        },
        binarySearch: function (index, count, value, comparer) {
            var obj2 = this._root;
            obj2;
            {
                return this._list.binarySearch(index, count, value, comparer);
            }
        },
        clear: function () {
            var obj2 = this._root;
            obj2;
            {
                this._list.clear();
            }
        },
        clone: function () {
            var obj2 = this._root;
            obj2;
            {
                return new System.Collections.ArrayList.SyncArrayList(Bridge.cast(this._list.clone(), System.Collections.ArrayList));
            }
        },
        contains: function (item) {
            var obj2 = this._root;
            obj2;
            {
                return this._list.contains(item);
            }
        },
        copyTo$1: function (array) {
            var obj2 = this._root;
            obj2;
            {
                this._list.copyTo$1(array);
            }
        },
        copyTo: function (array, index) {
            var obj2 = this._root;
            obj2;
            {
                this._list.copyTo(array, index);
            }
        },
        copyTo$2: function (index, array, arrayIndex, count) {
            var obj2 = this._root;
            obj2;
            {
                this._list.copyTo$2(index, array, arrayIndex, count);
            }
        },
        getEnumerator: function () {
            var obj2 = this._root;
            obj2;
            {
                return this._list.getEnumerator();
            }
        },
        getEnumerator$1: function (index, count) {
            var obj2 = this._root;
            obj2;
            {
                return this._list.getEnumerator$1(index, count);
            }
        },
        getRange: function (index, count) {
            var obj2 = this._root;
            obj2;
            {
                return this._list.getRange(index, count);
            }
        },
        indexOf: function (value) {
            var obj2 = this._root;
            obj2;
            {
                return this._list.indexOf(value);
            }
        },
        indexOf$1: function (value, startIndex) {
            var obj2 = this._root;
            obj2;
            {
                return this._list.indexOf$1(value, startIndex);
            }
        },
        indexOf$2: function (value, startIndex, count) {
            var obj2 = this._root;
            obj2;
            {
                return this._list.indexOf$2(value, startIndex, count);
            }
        },
        insert: function (index, value) {
            var obj2 = this._root;
            obj2;
            {
                this._list.insert(index, value);
            }
        },
        insertRange: function (index, c) {
            var obj2 = this._root;
            obj2;
            {
                this._list.insertRange(index, c);
            }
        },
        lastIndexOf: function (value) {
            var obj2 = this._root;
            obj2;
            {
                return this._list.lastIndexOf(value);
            }
        },
        lastIndexOf$1: function (value, startIndex) {
            var obj2 = this._root;
            obj2;
            {
                return this._list.lastIndexOf$1(value, startIndex);
            }
        },
        lastIndexOf$2: function (value, startIndex, count) {
            var obj2 = this._root;
            obj2;
            {
                return this._list.lastIndexOf$2(value, startIndex, count);
            }
        },
        remove: function (value) {
            var obj2 = this._root;
            obj2;
            {
                return this._list.remove(value);
            }
        },
        removeAt: function (index) {
            var obj2 = this._root;
            obj2;
            {
                this._list.removeAt(index);
            }
        },
        removeRange: function (index, count) {
            var obj2 = this._root;
            obj2;
            {
                this._list.removeRange(index, count);
            }
        },
        reverse$1: function (index, count) {
            var obj2 = this._root;
            obj2;
            {
                this._list.reverse$1(index, count);
            }
        },
        setRange: function (index, c) {
            var obj2 = this._root;
            obj2;
            {
                this._list.setRange(index, c);
            }
        },
        sort: function () {
            var obj2 = this._root;
            obj2;
            {
                this._list.sort();
            }
        },
        sort$1: function (comparer) {
            var obj2 = this._root;
            obj2;
            {
                this._list.sort$1(comparer);
            }
        },
        sort$2: function (index, count, comparer) {
            var obj2 = this._root;
            obj2;
            {
                this._list.sort$2(index, count, comparer);
            }
        },
        toArray$1: function () {
            var obj2 = this._root;
            obj2;
            {
                return this._list.toArray$1();
            }
        },
        toArray: function (type) {
            var obj2 = this._root;
            obj2;
            {
                return this._list.toArray(type);
            }
        },
        trimToSize: function () {
            var obj2 = this._root;
            obj2;
            {
                this._list.trimToSize();
            }
        }
    });
});

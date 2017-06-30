/**
 * @version 1.0.0.0
 * @copyright Copyright ©  2017
 * @compiler Bridge.NET 15.7.0
 */
Bridge.assembly("System.ComponentModel", function ($asm, globals) {
    "use strict";

    Bridge.define("System.ComponentModel.IComponent", {
        inherits: [System.IDisposable],
        $kind: "interface"
    });

    Bridge.define("System.ComponentModel.ComponentCollection", {
        inherits: [System.Collections.ReadOnlyCollectionBase]
    });

    Bridge.define("System.ComponentModel.EventHandlerList", {
        inherits: [System.IDisposable],
        head: null,
        parent: null,
        config: {
            alias: [
            "dispose", "System$IDisposable$dispose"
            ]
        },
        ctor: function () {
            this.$initialize();

        },
        $ctor1: function (parent) {
            this.$initialize();
            this.parent = parent;
        },
        getItem: function (key) {
            var entry = null;
            if ((this.parent == null) || this.parent.getCanRaiseEventsInternal()) {
                entry = this.find(key);
            }
            if (entry != null) {
                return entry.handler;
            }
            return null;
        },
        setItem: function (key, value) {
            var entry = this.find(key);
            if (entry != null) {
                entry.handler = value;
            } else {
                this.head = new System.ComponentModel.EventHandlerList.ListEntry(key, value, this.head);
            }
        },
        addHandler: function (key, value) {
            var entry = this.find(key);
            if (entry != null) {
                entry.handler = Bridge.fn.combine(entry.handler, value);
            } else {
                this.head = new System.ComponentModel.EventHandlerList.ListEntry(key, value, this.head);
            }
        },
        addHandlers: function (listToAddFrom) {
            for (var entry = listToAddFrom.head; entry != null; entry = entry.next) {
                this.addHandler(entry.key, entry.handler);
            }

        },
        dispose: function () {
            throw new System.NotImplementedException();
        },
        find: function (key) {
            var head = this.head;
            while (head != null) {
                if (Bridge.referenceEquals(head.key, key)) {
                    return head;
                }
                head = head.next;
            }
            return head;
        },
        removeHandler: function (key, value) {
            var entry = this.find(key);
            if (entry != null) {
                entry.handler = Bridge.fn.remove(entry.handler, value);
            }
        }
    });

    Bridge.define("System.ComponentModel.EventHandlerList.ListEntry", {
        handler: null,
        key: null,
        next: null,
        ctor: function (key, handler, next) {
            this.$initialize();
            this.next = next;
            this.key = key;
            this.handler = handler;
        }
    });

    Bridge.define("System.ComponentModel.IContainer", {
        inherits: [System.IDisposable],
        $kind: "interface"
    });

    Bridge.define("System.ComponentModel.ISite", {
        inherits: [System.IServiceProvider],
        $kind: "interface"
    });

    Bridge.define("System.ComponentModel.ISynchronizeInvoke", {
        $kind: "interface"
    });

    Bridge.define("System.ComponentModel.Component", {
        inherits: [System.MarshalByRefObject,System.ComponentModel.IComponent,System.IDisposable],
        statics: {
            eventDisposed: null
        },
        events: null,
        config: {
            alias: [
            "dispose", "System$IDisposable$dispose"
            ]
        },
        getCanRaiseEventsInternal: function () {
            return this.getCanRaiseEvents();
        },
        getCanRaiseEvents: function () {
            return true;
        },
        dispose: function () {
            throw new System.NotImplementedException();
        }
    });
});

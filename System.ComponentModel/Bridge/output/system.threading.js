/**
 * @version 1.0.0.0
 * @copyright Copyright ©  2017
 * @compiler Bridge.NET 15.7.0
 */
Bridge.assembly("System.Threading", function ($asm, globals) {
    "use strict";

    Bridge.define("System.Threading.Interlock", {
        statics: {
            add: function (location1, value) {
                return (((System.Threading.Interlock.exchangeAdd(location1, value) + value) | 0));
            },
            add$1: function (location1, value) {
                return (System.Threading.Interlock.exchangeAdd$1(location1, value).add(value));
            },
            compareExchange$1: function (location1, value, comparand) {
                if (location1.v === value) {
                    location1.v = comparand;
                }
                return location1.v;
            },
            compareExchange$2: function (location1, value, comparand) {
                if (location1.v === value) {
                    location1.v = comparand;
                }
                return location1.v;
            },
            compareExchange$3: function (location1, value, comparand) {
                if (location1.v.equals(value)) {
                    location1.v = comparand;
                }
                return location1.v;
            },
            compareExchange$4: function (location1, value, comparand) {
                if (Bridge.equals(location1.v, value)) {
                    location1.v = comparand;
                }
                return location1.v;
            },
            compareExchange$5: function (location1, value, comparand) {
                if (Bridge.referenceEquals(location1.v, value)) {
                    location1.v = comparand;
                }
                return location1.v;
            },
            compareExchange$6: function (location1, value, comparand) {
                if (location1.v === value) {
                    location1.v = comparand;
                }
                return location1.v;
            },
            compareExchange: function (T, location1, value, comparand) {
                if (Bridge.referenceEquals(location1.v, value)) {
                    location1.v = comparand;
                }
                return location1.v;
            },
            decrement: function (location) {
                return System.Threading.Interlock.add(location, -1);
            },
            decrement$1: function (location) {
                return System.Threading.Interlock.add$1(location, System.Int64(-1));
            },
            exchange$1: function (location1, value) {
                location1.v = value;
                return value;
            },
            exchange$2: function (location1, value) {
                location1.v = value;
                return value;
            },
            exchange$3: function (location1, value) {
                location1.v = value;
                return value;
            },
            exchange$4: function (location1, value) {
                location1.v = value;
                return value;
            },
            exchange$5: function (location1, value) {
                location1.v = value;
                return value;
            },
            exchange$6: function (location1, value) {
                location1.v = value;
                return value;
            },
            exchange: function (T, location1, value) {
                location1.v = value;
                return value;
            },
            exchangeAdd: function (location1, value) {
                System.Threading.Interlock.exchange$2(location1, value);
                return System.Threading.Interlock.add(location1, value);
            },
            exchangeAdd$1: function (location1, value) {
                System.Threading.Interlock.exchange$3(location1, value);
                return System.Threading.Interlock.add$1(location1, value);
            },
            increment: function (location) {
                return System.Threading.Interlock.add(location, 1);
            },
            increment$1: function (location) {
                return System.Threading.Interlock.add$1(location, System.Int64(1));
            },
            memoryBarrier: function () {
                throw new System.NotImplementedException();
            },
            read: function (location) {
                return System.Threading.Interlock.compareExchange$3(location, System.Int64(0), System.Int64(0));
            }
        }
    });
});

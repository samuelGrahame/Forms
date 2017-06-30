/**
 * @version 1.0.0.0
 * @copyright Copyright ©  2017
 * @compiler Bridge.NET 15.7.0
 */
Bridge.assembly("System", function ($asm, globals) {
    "use strict";

    Bridge.define("System.EmptyArray$1", function (T) { return {
        statics: {
            ctor: function () {
                System.EmptyArray$1(T).value = System.Array.init(0, function (){
                    return Bridge.getDefaultValue(T);
                }, T);
            },
            value: null
        }
    }; });

    Bridge.define("System.IServiceProvider", {
        $kind: "interface"
    });

    Bridge.define("System.MarshalByRefObject");
});

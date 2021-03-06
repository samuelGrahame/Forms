/**
 * @version 1.0.0.0
 * @copyright Copyright ©  2017
 * @compiler Bridge.NET 15.7.0
 */
Bridge.assembly("System.Windows.Forms", function ($asm, globals) {
    "use strict";

    Bridge.define("System.Windows.Forms.IContainerControl", {
        $kind: "interface"
    });

    Bridge.define("System.Windows.Forms.IComponent", {
        $kind: "interface"
    });

    Bridge.define("System.Windows.Forms.IArrangedElement", {
        $kind: "interface"
    });

    Bridge.define("System.Windows.Forms.IWin32Window", {
        $kind: "interface"
    });

    Bridge.define("System.Windows.Forms.IDropTarget", {
        $kind: "interface"
    });

    Bridge.define("System.Windows.Forms.IBindableComponent", {
        inherits: [System.Windows.Forms.IComponent,System.IDisposable],
        $kind: "interface"
    });

    Bridge.define("System.Windows.Forms.Control", {
        inherits: [System.ComponentModel.Component,System.Windows.Forms.IDropTarget,System.ComponentModel.ISynchronizeInvoke,System.Windows.Forms.IWin32Window,System.Windows.Forms.IArrangedElement,System.Windows.Forms.IComponent,System.IDisposable,System.Windows.Forms.IBindableComponent]
    });

    Bridge.define("System.Windows.Forms.ScrollableControl", {
        inherits: [System.Windows.Forms.Control,System.Windows.Forms.IArrangedElement,System.Windows.Forms.IComponent,System.IDisposable]
    });

    Bridge.define("System.Windows.Forms.ContainerControl", {
        inherits: [System.Windows.Forms.ScrollableControl,System.Windows.Forms.IContainerControl]
    });

    Bridge.define("System.Windows.Forms.Form", {
        inherits: [System.Windows.Forms.ContainerControl]
    });
});

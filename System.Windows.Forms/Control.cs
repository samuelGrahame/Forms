﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Windows.Forms
{
    public class Control : Component, IDropTarget, ISynchronizeInvoke, IWin32Window, IArrangedElement, IComponent, IDisposable, IBindableComponent
    {
        // #TODO Create All Field Types

        internal static readonly BooleanSwitch BufferPinkRect;
        private LayoutEventArgs cachedLayoutEventArgs;
        private static bool checkForIllegalCrossThreadCalls;
        private int clientHeight;
        private int clientWidth;
        internal static readonly TraceSwitch ControlKeyboardRouting;
        private ControlStyles controlStyle;
        private CreateParams createParams;
        [ThreadStatic]
        internal static HelpInfo currentHelpInfo;
        private static Font defaultFont;
        private static FontHandleWrapper defaultFontHandleWrapper;
        internal int deviceDpi;
        private static readonly object EventAutoSizeChanged;
        private static readonly object EventBackColor;
        private static readonly object EventBackgroundImage;
        private static readonly object EventBackgroundImageLayout;
        private static readonly object EventBindingContext;
        private static readonly object EventCausesValidation;
        private static readonly object EventChangeUICues;
        private static readonly object EventClick;
        private static readonly object EventClientSize;
        private static readonly object EventContextMenu;
        private static readonly object EventContextMenuStrip;
        private static readonly object EventControlAdded;
        private static readonly object EventControlRemoved;
        private static readonly object EventCursor;
        private static readonly object EventDock;
        private static readonly object EventDoubleClick;
        private static readonly object EventDpiChangedAfterParent;
        private static readonly object EventDpiChangedBeforeParent;
        private static readonly object EventDragDrop;
        private static readonly object EventDragEnter;
        private static readonly object EventDragLeave;
        private static readonly object EventDragOver;
        private static readonly object EventEnabled;
        private static readonly object EventEnabledChanged;
        private static readonly object EventEnter;
        private static readonly object EventFont;
        private static readonly object EventForeColor;
        private static readonly object EventGiveFeedback;
        private static readonly object EventGotFocus;
        private static readonly object EventHandleCreated;
        private static readonly object EventHandleDestroyed;
        private static readonly object EventHelpRequested;
        private static readonly object EventImeModeChanged;
        private static readonly object EventInvalidated;
        private static readonly object EventKeyDown;
        private static readonly object EventKeyPress;
        private static readonly object EventKeyUp;
        private static readonly object EventLayout;
        private static readonly object EventLeave;
        private static readonly object EventLocation;
        private static readonly object EventLostFocus;
        private static readonly object EventMarginChanged;
        private static readonly object EventMouseCaptureChanged;
        private static readonly object EventMouseClick;
        private static readonly object EventMouseDoubleClick;
        private static readonly object EventMouseDown;
        private static readonly object EventMouseEnter;
        private static readonly object EventMouseHover;
        private static readonly object EventMouseLeave;
        private static readonly object EventMouseMove;
        private static readonly object EventMouseUp;
        private static readonly object EventMouseWheel;
        private static readonly object EventMove;
        internal static readonly object EventPaddingChanged;
        private static readonly object EventPaint;
        private static readonly object EventParent;
        private static readonly object EventPreviewKeyDown;
        private static readonly object EventQueryAccessibilityHelp;
        private static readonly object EventQueryContinueDrag;
        private static readonly object EventRegionChanged;
        private static readonly object EventResize;
        private static readonly object EventRightToLeft;
        private static readonly object EventSize;
        private static readonly object EventStyleChanged;
        private static readonly object EventSystemColorsChanged;
        private static readonly object EventTabIndex;
        private static readonly object EventTabStop;
        private static readonly object EventText;
        private static readonly object EventValidated;
        private static readonly object EventValidating;
        private static readonly object EventVisible;
        private static readonly object EventVisibleChanged;
        internal static readonly TraceSwitch FocusTracing;
        private int height;
        private static bool ignoreWmImeNotify;
        private const int ImeCharsToIgnoreDisabled = -1;
        private const int ImeCharsToIgnoreEnabled = 0;
        
        private static bool inCrossThreadSafeCall;
        private static ContextCallback invokeMarshaledCallbackHelperDelegate;
        private static bool lastLanguageChinese;
        private byte layoutSuspendCount;
        private static bool mouseWheelInit;
        private static int mouseWheelMessage;
        private static bool mouseWheelRoutingNeeded;
        private const short PaintLayerBackground = 1;
        private const short PaintLayerForeground = 2;
        internal static readonly TraceSwitch PaletteTracing;
        private Control parent;
        private static readonly int PropAccessibility;
        private static readonly int PropAccessibleDefaultActionDescription;
        private static readonly int PropAccessibleDescription;
        private static readonly int PropAccessibleHelpProvider;
        private static readonly int PropAccessibleName;
        private static readonly int PropAccessibleRole;
        private static readonly int PropActiveXImpl;
        private static ImeMode propagatingImeMode;
        private static readonly int PropAmbientPropertiesService;
        private static readonly int PropAutoScrollOffset;
        private static readonly int PropBackBrush;
        private static readonly int PropBackColor;
        private static readonly int PropBackgroundImage;
        private static readonly int PropBackgroundImageLayout;
        private static readonly int PropBindingManager;
        private static readonly int PropBindings;
        private static readonly int PropCacheTextCount;
        private static readonly int PropCacheTextField;
        private static readonly int PropContextMenu;
        private static readonly int PropContextMenuStrip;
        private static readonly int PropControlsCollection;
        private static readonly int PropControlVersionInfo;
        private static readonly int PropCurrentAmbientFont;
        private static readonly int PropCursor;
        private static readonly int PropDisableImeModeChangedCount;
        private PropertyStore propertyStore;
        private static readonly int PropFont;
        private static readonly int PropFontHandleWrapper;
        private static readonly int PropFontHeight;
        private static readonly int PropForeColor;
        private static readonly int PropImeMode;
        private static readonly int PropImeWmCharsToIgnore;
        private static readonly int PropLastCanEnableIme;
        private static readonly int PropName;
        private static readonly int PropNcAccessibility;
        private static readonly int PropPaintingException;
        private static readonly int PropRegion;
        private static readonly int PropRightToLeft;
        private static readonly int PropUseCompatibleTextRendering;
        private static readonly int PropUserData;
        private Control reflectParent;
        private byte requiredScaling;
        private const byte RequiredScalingEnabledMask = 0x10;
        private const byte RequiredScalingMask = 15;
        private int state;
        internal const int STATE_ALLOWDROP = 0x40;
        internal const int STATE_CAUSESVALIDATION = 0x20000;
        internal const int STATE_CHECKEDHOST = 0x1000000;
        internal const int STATE_CREATED = 1;
        internal const int STATE_CREATINGHANDLE = 0x40000;
        internal const int STATE_DISPOSED = 0x800;
        internal const int STATE_DISPOSING = 0x1000;
        internal const int STATE_DOUBLECLICKFIRED = 0x4000000;
        internal const int STATE_DROPTARGET = 0x80;
        internal const int STATE_ENABLED = 4;
        internal const int STATE_EXCEPTIONWHILEPAINTING = 0x400000;
        internal const int STATE_HOSTEDINDIALOG = 0x2000000;
        internal const int STATE_ISACCESSIBLE = 0x100000;
        internal const int STATE_LAYOUTDEFERRED = 0x200;
        internal const int STATE_LAYOUTISDIRTY = 0x800000;
        internal const int STATE_MIRRORED = 0x40000000;
        internal const int STATE_MODAL = 0x20;
        internal const int STATE_MOUSEENTERPENDING = 0x2000;
        internal const int STATE_MOUSEPRESSED = 0x8000000;
        internal const int STATE_NOZORDER = 0x100;
        internal const int STATE_OWNCTLBRUSH = 0x200000;
        internal const int STATE_PARENTRECREATING = 0x20000000;
        internal const int STATE_RECREATE = 0x10;
        internal const int STATE_SIZELOCKEDBYOS = 0x10000;
        internal const int STATE_TABSTOP = 8;
        internal const int STATE_THREADMARSHALLPENDING = 0x8000;
        internal const int STATE_TOPLEVEL = 0x80000;
        internal const int STATE_TRACKINGMOUSEEVENT = 0x4000;
        internal const int STATE_USEWAITCURSOR = 0x400;
        internal const int STATE_VALIDATIONCANCELLED = 0x10000000;
        internal const int STATE_VISIBLE = 2;
        private int state2;
        private const int STATE2_BECOMINGACTIVECONTROL = 0x20;
        private const int STATE2_CLEARLAYOUTARGS = 0x40;
        internal const int STATE2_CURRENTLYBEINGSCALED = 0x2000;
        private const int STATE2_HAVEINVOKED = 1;
        private const int STATE2_INPUTCHAR = 0x100;
        private const int STATE2_INPUTKEY = 0x80;
        internal const int STATE2_INTERESTEDINUSERPREFERENCECHANGED = 8;
        private const int STATE2_ISACTIVEX = 0x400;
        private const int STATE2_LISTENINGTOUSERPREFERENCECHANGED = 4;
        internal const int STATE2_MAINTAINSOWNCAPTUREMODE = 0x10;
        private const int STATE2_SETSCROLLPOS = 2;
        internal const int STATE2_TOPMDIWINDOWCLOSING = 0x1000;
        private const int STATE2_UICUES = 0x200;
        internal const int STATE2_USEPREFERREDSIZECACHE = 0x800;
        private int tabIndex;
        private string text;
        private Queue threadCallbackList;
        private static int threadCallbackMessage;
        private NativeMethods.TRACKMOUSEEVENT trackMouseEvent;
        private int uiCuesState;
        private const int UISTATE_FOCUS_CUES_HIDDEN = 1;
        private const int UISTATE_FOCUS_CUES_MASK = 15;
        private const int UISTATE_FOCUS_CUES_SHOW = 2;
        private const int UISTATE_KEYBOARD_CUES_HIDDEN = 0x10;
        private const int UISTATE_KEYBOARD_CUES_MASK = 240;
        private const int UISTATE_KEYBOARD_CUES_SHOW = 0x20;
        private short updateCount;
        internal static bool UseCompatibleTextRenderingDefault;
        private int width;
        private ControlNativeWindow window;
        private static int WM_GETCONTROLNAME;
        private static int WM_GETCONTROLTYPE;
        private int x;
        private int y;

        // Events: #TODO: Create other Event Handler Types
        public event EventHandler AutoSizeChanged;
        
        public event EventHandler BackColorChanged;
        
        public event EventHandler BackgroundImageChanged;
        
        public event EventHandler BackgroundImageLayoutChanged;
        
        public event EventHandler BindingContextChanged;
        
        public event EventHandler CausesValidationChanged;
        
        public event UICuesEventHandler ChangeUICues;
        
        public event EventHandler Click;
        
        public event EventHandler ClientSizeChanged;
        
        public event EventHandler ContextMenuChanged;
        
        public event EventHandler ContextMenuStripChanged;
        
        public event ControlEventHandler ControlAdded;
        
        public event ControlEventHandler ControlRemoved;
        
        public event EventHandler CursorChanged;
        
        public event EventHandler DockChanged;
        
        public event EventHandler DoubleClick;
        
        public event EventHandler DpiChangedAfterParent;
        
        public event EventHandler DpiChangedBeforeParent;
        
        public event DragEventHandler DragDrop;
        
        public event DragEventHandler DragEnter;
        
        public event EventHandler DragLeave;
        
        public event DragEventHandler DragOver;
        
        public event EventHandler EnabledChanged;
        
        public event EventHandler Enter;
        
        public event EventHandler FontChanged;
        
        public event EventHandler ForeColorChanged;
        
        public event GiveFeedbackEventHandler GiveFeedback;
        
        public event EventHandler GotFocus;
        
        public event EventHandler HandleCreated;
        
        public event EventHandler HandleDestroyed;
        
        public event HelpEventHandler HelpRequested;
        
        public event EventHandler ImeModeChanged;
        
        public event InvalidateEventHandler Invalidated;
        
        public event KeyEventHandler KeyDown;
        
        public event KeyPressEventHandler KeyPress;
        
        public event KeyEventHandler KeyUp;
        
        public event LayoutEventHandler Layout;
        
        public event EventHandler Leave;
        
        public event EventHandler LocationChanged;
        
        public event EventHandler LostFocus;
        
        public event EventHandler MarginChanged;
        
        public event EventHandler MouseCaptureChanged;
        
        public event MouseEventHandler MouseClick;
        
        public event MouseEventHandler MouseDoubleClick;
        
        public event MouseEventHandler MouseDown;
        
        public event EventHandler MouseEnter;
        
        public event EventHandler MouseHover;
        
        public event EventHandler MouseLeave;
        
        public event MouseEventHandler MouseMove;
        
        public event MouseEventHandler MouseUp;
        
        public event MouseEventHandler MouseWheel;
        
        public event EventHandler Move;
        
        public event EventHandler PaddingChanged;
        
        public event PaintEventHandler Paint;
        
        public event EventHandler ParentChanged;
        
        public event PreviewKeyDownEventHandler PreviewKeyDown;
        
        public event QueryAccessibilityHelpEventHandler QueryAccessibilityHelp;
        
        public event QueryContinueDragEventHandler QueryContinueDrag;
        
        public event EventHandler RegionChanged;
        
        public event EventHandler Resize;
        
        public event EventHandler RightToLeftChanged;
        
        public event EventHandler SizeChanged;
        
        public event EventHandler StyleChanged;
        
        public event EventHandler SystemColorsChanged;
        
        public event EventHandler TabIndexChanged;
        
        public event EventHandler TabStopChanged;
        
        public event EventHandler TextChanged;
        
        public event EventHandler Validated;
        
        public event CancelEventHandler Validating;
        
        public event EventHandler VisibleChanged;



    }
}

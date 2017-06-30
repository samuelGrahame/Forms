using System;
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

        // #TODO: Fix

        static Control();
        public Control();
        internal Control(bool autoInstallSyncContext);
        public Control(string text);
        public Control(Control parent, string text);
        public Control(string text, int left, int top, int width, int height);
        public Control(Control parent, string text, int left, int top, int width, int height);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected internal void AccessibilityNotifyClients(AccessibleEvents accEvent, int childID);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected void AccessibilityNotifyClients(AccessibleEvents accEvent, int objectID, int childID);
        private IntPtr ActiveXMergeRegion(IntPtr region);
        private void ActiveXOnFocus(bool focus);
        private void ActiveXUpdateBounds(ref int x, ref int y, ref int width, ref int height, int flags);
        private void ActiveXViewChanged();
        internal virtual void AddReflectChild();
        internal void AdjustWindowRectEx(ref NativeMethods.RECT rect, int style, bool bMenu, int exStyle);
        internal virtual Rectangle ApplyBoundsConstraints(int suggestedX, int suggestedY, int proposedWidth, int proposedHeight);
        internal Size ApplySizeConstraints(Size proposedSize);
        internal Size ApplySizeConstraints(int width, int height);
        internal virtual void AssignParent(Control value);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public IAsyncResult BeginInvoke(Delegate method);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public IAsyncResult BeginInvoke(Delegate method, params object[] args);
        internal void BeginUpdateInternal();
        public void BringToFront();
        internal virtual bool CanProcessMnemonic();
        internal virtual bool CanSelectCore();
        internal static void CheckParentingCycle(Control bottom, Control toFind);
        private void ChildGotFocus(Control child);
        public bool Contains(Control ctl);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual AccessibleObject CreateAccessibilityInstance();
        public void CreateControl();
        internal void CreateControl(bool fIgnoreVisible);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual ControlCollection CreateControlsInstance();
        public Graphics CreateGraphics();
        internal Graphics CreateGraphicsInternal();
        [EditorBrowsable(EditorBrowsableState.Advanced), UIPermission(SecurityAction.InheritanceDemand, Window = UIPermissionWindow.AllWindows)]
        protected virtual void CreateHandle();
        [EditorBrowsable(EditorBrowsableState.Advanced), SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.UnmanagedCode), SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected virtual void DefWndProc(ref Message m);
        [EditorBrowsable(EditorBrowsableState.Advanced), SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.UnmanagedCode), UIPermission(SecurityAction.LinkDemand, Window = UIPermissionWindow.AllWindows)]
        protected virtual void DestroyHandle();
        private void DetachContextMenu(object sender, EventArgs e);
        private void DetachContextMenuStrip(object sender, EventArgs e);
        protected override void Dispose(bool disposing);
        internal virtual void DisposeAxControls();
        private void DisposeFontHandle();
        [UIPermission(SecurityAction.Demand, Clipboard = UIPermissionClipboard.OwnClipboard)]
        public DragDropEffects DoDragDrop(object data, DragDropEffects allowedEffects);
        [UIPermission(SecurityAction.Demand, Window = UIPermissionWindow.AllWindows)]
        public void DrawToBitmap(Bitmap bitmap, Rectangle targetBounds);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public object EndInvoke(IAsyncResult asyncResult);
        internal bool EndUpdateInternal();
        internal bool EndUpdateInternal(bool invalidate);
        [UIPermission(SecurityAction.Demand, Window = UIPermissionWindow.AllWindows)]
        public Form FindForm();
        internal Form FindFormInternal();
        private Control FindMarshalingControl();
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public bool Focus();
        internal virtual bool FocusInternal();
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Control FromChildHandle(IntPtr handle);
        internal static Control FromChildHandleInternal(IntPtr handle);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public static Control FromHandle(IntPtr handle);
        internal static Control FromHandleInternal(IntPtr handle);
        private AccessibleObject GetAccessibilityObject(int accObjId);
        protected virtual AccessibleObject GetAccessibilityObjectById(int objectId);
        internal bool GetAnyDisposingInHierarchy();
        protected AutoSizeMode GetAutoSizeMode();
        internal static AutoValidate GetAutoValidateForControl(Control control);
        public Control GetChildAtPoint(Point pt);
        public Control GetChildAtPoint(Point pt, GetChildAtPointSkip skipValue);
        internal Control[] GetChildControlsInTabOrder(bool handleCreatedOnly);
        private ArrayList GetChildControlsTabOrderList(bool handleCreatedOnly);
        private static ArrayList GetChildWindows(IntPtr hWndParent);
        private int[] GetChildWindowsInTabOrder();
        private ArrayList GetChildWindowsTabOrderList();
        public IContainerControl GetContainerControl();
        internal IContainerControl GetContainerControlInternal();
        private static FontHandleWrapper GetDefaultFontHandleWrapper();
        internal virtual Control GetFirstChildControlInTabOrder(bool forward);
        internal IntPtr GetHRgn(Region region);
        private MenuItem GetMenuItemFromHandleId(IntPtr hmenu, int item);
        public Control GetNextControl(Control ctl, bool forward);
        private Font GetParentFont();
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public virtual Size GetPreferredSize(Size proposedSize);
        internal virtual Size GetPreferredSizeCore(Size proposedSize);
        internal static IntPtr GetSafeHandle(IWin32Window window);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual Rectangle GetScaledBounds(Rectangle bounds, SizeF factor, BoundsSpecified specified);
        internal bool GetState(int flag);
        private bool GetState2(int flag);
        protected bool GetStyle(ControlStyles flag);
        protected bool GetTopLevel();
        internal virtual bool GetVisibleCore();
        private MouseButtons GetXButton(int wparam);
        public void Hide();
        private void HookMouseEvent();
        internal virtual IntPtr InitializeDCForWmCtlColor(IntPtr dc, int msg);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void InitLayout();
        private void InitMouseWheelSupport();
        private void InitScaling(BoundsSpecified specified);
        public void Invalidate();
        public void Invalidate(bool invalidateChildren);
        public void Invalidate(Rectangle rc);
        public void Invalidate(Region region);
        public void Invalidate(Rectangle rc, bool invalidateChildren);
        public void Invalidate(Region region, bool invalidateChildren);
        public object Invoke(Delegate method);
        public object Invoke(Delegate method, params object[] args);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected void InvokeGotFocus(Control toInvoke, EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected void InvokeLostFocus(Control toInvoke, EventArgs e);
        private void InvokeMarshaledCallback(ThreadMethodEntry tme);
        private static void InvokeMarshaledCallbackDo(ThreadMethodEntry tme);
        private static void InvokeMarshaledCallbackHelper(object obj);
        private void InvokeMarshaledCallbacks();
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected void InvokeOnClick(Control toInvoke, EventArgs e);
        protected void InvokePaint(Control c, PaintEventArgs e);
        protected void InvokePaintBackground(Control c, PaintEventArgs e);
        internal bool IsDescendant(Control descendant);
        private static bool IsFocusManagingContainerControl(Control ctl);
        internal bool IsFontSet();
        [UIPermission(SecurityAction.InheritanceDemand, Window = UIPermissionWindow.AllWindows)]
        protected virtual bool IsInputChar(char charCode);
        [UIPermission(SecurityAction.InheritanceDemand, Window = UIPermissionWindow.AllWindows)]
        protected virtual bool IsInputKey(Keys keyData);
        public static bool IsKeyLocked(Keys keyVal);
        public static bool IsMnemonic(char charCode, string text);
        internal bool IsUpdating();
        private bool IsValidBackColor(Color c);
        private void ListenToUserPreferenceChanged(bool listen);
        public int LogicalToDeviceUnits(int value);
        private object MarshaledInvoke(Control caller, Delegate method, object[] args, bool synchronous);
        private void MarshalStringToMessage(string value, ref Message m);
        internal void NotifyEnter();
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void NotifyInvalidate(Rectangle invalidatedArea);
        internal void NotifyLeave();
        private void NotifyValidated();
        private bool NotifyValidating();
        internal virtual void NotifyValidationResult(object sender, CancelEventArgs ev);
        protected virtual void OnAutoSizeChanged(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnBackColorChanged(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnBackgroundImageChanged(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnBackgroundImageLayoutChanged(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnBindingContextChanged(EventArgs e);
        internal virtual void OnBoundsUpdate(int x, int y, int width, int height);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnCausesValidationChanged(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnChangeUICues(UICuesEventArgs e);
        internal virtual void OnChildLayoutResuming(Control child, bool performLayout);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnClick(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnClientSizeChanged(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnContextMenuChanged(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnContextMenuStripChanged(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnControlAdded(ControlEventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnControlRemoved(ControlEventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnCreateControl();
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnCursorChanged(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnDockChanged(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnDoubleClick(EventArgs e);
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        protected virtual void OnDpiChangedAfterParent(EventArgs e);
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        protected virtual void OnDpiChangedBeforeParent(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnDragDrop(DragEventArgs drgevent);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnDragEnter(DragEventArgs drgevent);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnDragLeave(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnDragOver(DragEventArgs drgevent);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnEnabledChanged(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnEnter(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnFontChanged(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnForeColorChanged(EventArgs e);
        internal virtual void OnFrameWindowActivate(bool fActivate);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnGiveFeedback(GiveFeedbackEventArgs gfbevent);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnGotFocus(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnHandleCreated(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnHandleDestroyed(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnHelpRequested(HelpEventArgs hevent);
        internal void OnImeContextStatusChanged(IntPtr handle);
        protected virtual void OnImeModeChanged(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnInvalidated(InvalidateEventArgs e);
        internal virtual void OnInvokedSetScrollPosition(object sender, EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnKeyDown(KeyEventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnKeyPress(KeyPressEventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnKeyUp(KeyEventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnLayout(LayoutEventArgs levent);
        internal virtual void OnLayoutResuming(bool performLayout);
        internal virtual void OnLayoutSuspended();
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnLeave(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnLocationChanged(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnLostFocus(EventArgs e);
        protected virtual void OnMarginChanged(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnMouseCaptureChanged(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnMouseClick(MouseEventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnMouseDoubleClick(MouseEventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnMouseDown(MouseEventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnMouseEnter(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnMouseHover(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnMouseLeave(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnMouseMove(MouseEventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnMouseUp(MouseEventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnMouseWheel(MouseEventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnMove(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnNotifyMessage(Message m);
        protected virtual void OnPaddingChanged(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnPaint(PaintEventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnPaintBackground(PaintEventArgs pevent);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnParentBackColorChanged(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnParentBackgroundImageChanged(EventArgs e);
        internal virtual void OnParentBecameInvisible();
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnParentBindingContextChanged(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnParentChanged(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnParentCursorChanged(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnParentEnabledChanged(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnParentFontChanged(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnParentForeColorChanged(EventArgs e);
        internal virtual void OnParentHandleRecreated();
        internal virtual void OnParentHandleRecreating();
        private void OnParentInvalidated(InvalidateEventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnParentRightToLeftChanged(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnParentVisibleChanged(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced), SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.UnmanagedCode), SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected virtual void OnPreviewKeyDown(PreviewKeyDownEventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnPrint(PaintEventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnQueryContinueDrag(QueryContinueDragEventArgs qcdevent);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnRegionChanged(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnResize(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnRightToLeftChanged(EventArgs e);
        private void OnSetScrollPosition(object sender, EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnSizeChanged(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnStyleChanged(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnSystemColorsChanged(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnTabIndexChanged(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnTabStopChanged(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnTextChanged(EventArgs e);
        internal virtual void OnTopMostActiveXParentChanged(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnValidated(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnValidating(CancelEventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnVisibleChanged(EventArgs e);
        private static void PaintBackColor(PaintEventArgs e, Rectangle rectangle, Color backColor);
        internal void PaintBackground(PaintEventArgs e, Rectangle rectangle);
        internal void PaintBackground(PaintEventArgs e, Rectangle rectangle, Color backColor);
        internal void PaintBackground(PaintEventArgs e, Rectangle rectangle, Color backColor, Point scrollOffset);
        private void PaintException(PaintEventArgs e);
        internal void PaintTransparentBackground(PaintEventArgs e, Rectangle rectangle);
        internal void PaintTransparentBackground(PaintEventArgs e, Rectangle rectangle, Region transparentRegion);
        private void PaintWithErrorHandling(PaintEventArgs e, short layer);
        internal bool PerformContainerValidation(ValidationConstraints validationConstraints);
        internal bool PerformControlValidation(bool bulkValidation);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public void PerformLayout();
        internal void PerformLayout(LayoutEventArgs args);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public void PerformLayout(Control affectedControl, string affectedProperty);
        public Point PointToClient(Point p);
        internal Point PointToClientInternal(Point p);
        public Point PointToScreen(Point p);
        [EditorBrowsable(EditorBrowsableState.Advanced), SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public PreProcessControlState PreProcessControlMessage(ref Message msg);
        internal static PreProcessControlState PreProcessControlMessageInternal(Control target, ref Message msg);
        [SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.UnmanagedCode), SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public virtual bool PreProcessMessage(ref Message msg);
        private void PrintToMetaFile(HandleRef hDC, IntPtr lParam);
        private void PrintToMetaFile_SendPrintMessage(HandleRef hDC, IntPtr lParam);
        internal virtual void PrintToMetaFileRecursive(HandleRef hDC, IntPtr lParam, Rectangle bounds);
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode), SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected virtual bool ProcessCmdKey(ref Message msg, Keys keyData);
        [UIPermission(SecurityAction.InheritanceDemand, Window = UIPermissionWindow.AllWindows), UIPermission(SecurityAction.LinkDemand, Window = UIPermissionWindow.AllWindows)]
        protected virtual bool ProcessDialogChar(char charCode);
        [UIPermission(SecurityAction.InheritanceDemand, Window = UIPermissionWindow.AllWindows), UIPermission(SecurityAction.LinkDemand, Window = UIPermissionWindow.AllWindows)]
        protected virtual bool ProcessDialogKey(Keys keyData);
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode), SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected virtual bool ProcessKeyEventArgs(ref Message m);
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode), SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected internal virtual bool ProcessKeyMessage(ref Message m);
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode), SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected virtual bool ProcessKeyPreview(ref Message m);
        [UIPermission(SecurityAction.InheritanceDemand, Window = UIPermissionWindow.AllWindows), UIPermission(SecurityAction.LinkDemand, Window = UIPermissionWindow.AllWindows)]
        protected internal virtual bool ProcessMnemonic(char charCode);
        internal void ProcessUICues(ref Message msg);
        internal void RaiseCreateHandleEvent(EventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected void RaiseDragEvent(object key, DragEventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected void RaiseKeyEvent(object key, KeyEventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected void RaiseMouseEvent(object key, MouseEventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected void RaisePaintEvent(object key, PaintEventArgs e);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected void RecreateHandle();
        internal virtual void RecreateHandleCore();
        public Rectangle RectangleToClient(Rectangle r);
        public Rectangle RectangleToScreen(Rectangle r);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected static bool ReflectMessage(IntPtr hWnd, ref Message m);
        internal static bool ReflectMessageInternal(IntPtr hWnd, ref Message m);
        public virtual void Refresh();
        private void RemovePendingMessages(int msgMin, int msgMax);
        internal virtual void RemoveReflectChild();
        private bool RenderColorTransparent(Color c);
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void RescaleConstantsForDpi(int deviceDpiOld, int deviceDpiNew);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ResetBackColor();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ResetBindings();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ResetCursor();
        private void ResetEnabled();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ResetFont();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ResetForeColor();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ResetImeMode();
        private void ResetLocation();
        private void ResetMargin();
        private void ResetMinimumSize();
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected void ResetMouseEventArgs();
        private void ResetPadding();
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void ResetRightToLeft();
        private void ResetSize();
        public virtual void ResetText();
        private void ResetVisible();
        public void ResumeLayout();
        public void ResumeLayout(bool performLayout);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected ContentAlignment RtlTranslateAlignment(ContentAlignment align);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected HorizontalAlignment RtlTranslateAlignment(HorizontalAlignment align);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected LeftRightAlignment RtlTranslateAlignment(LeftRightAlignment align);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected internal ContentAlignment RtlTranslateContent(ContentAlignment align);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected HorizontalAlignment RtlTranslateHorizontal(HorizontalAlignment align);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected LeftRightAlignment RtlTranslateLeftRight(LeftRightAlignment align);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public void Scale(SizeF factor);
        [Obsolete("This method has been deprecated. Use the Scale(SizeF ratio) method instead. http://go.microsoft.com/fwlink/?linkid=14202"), EditorBrowsable(EditorBrowsableState.Never)]
        public void Scale(float ratio);
        [Obsolete("This method has been deprecated. Use the Scale(SizeF ratio) method instead. http://go.microsoft.com/fwlink/?linkid=14202"), EditorBrowsable(EditorBrowsableState.Never)]
        public void Scale(float dx, float dy);
        internal virtual void Scale(SizeF includedFactor, SizeF excludedFactor, Control requestingControl);
        public void ScaleBitmapLogicalToDevice(ref Bitmap logicalBitmap);
        internal void ScaleChildControls(SizeF includedFactor, SizeF excludedFactor, Control requestingControl);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void ScaleControl(SizeF factor, BoundsSpecified specified);
        internal void ScaleControl(SizeF includedFactor, SizeF excludedFactor, Control requestingControl);
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void ScaleCore(float dx, float dy);
        internal void ScaleFont(float factor);
        internal Size ScaleSize(Size startSize, float x, float y);
        public void Select();
        protected virtual void Select(bool directed, bool forward);
        public bool SelectNextControl(Control ctl, bool forward, bool tabStopOnly, bool nested, bool wrap);
        internal bool SelectNextControlInternal(Control ctl, bool forward, bool tabStopOnly, bool nested, bool wrap);
        private void SelectNextIfFocused();
        internal IntPtr SendMessage(int msg, bool wparam, int lparam);
        internal IntPtr SendMessage(int msg, int wparam, int lparam);
        internal IntPtr SendMessage(int msg, ref int wparam, ref int lparam);
        internal IntPtr SendMessage(int msg, int wparam, IntPtr lparam);
        internal IntPtr SendMessage(int msg, int wparam, ref NativeMethods.RECT lparam);
        internal IntPtr SendMessage(int msg, int wparam, string lparam);
        internal IntPtr SendMessage(int msg, IntPtr wparam, int lparam);
        internal IntPtr SendMessage(int msg, IntPtr wparam, IntPtr lparam);
        public void SendToBack();
        internal void SetAcceptDrops(bool accept);
        protected void SetAutoSizeMode(AutoSizeMode mode);
        public void SetBounds(int x, int y, int width, int height);
        public void SetBounds(int x, int y, int width, int height, BoundsSpecified specified);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void SetClientSizeCore(int x, int y);
        private void SetHandle(IntPtr value);
        private void SetParentHandle(IntPtr value);
        internal void SetState(int flag, bool value);
        internal void SetState2(int flag, bool value);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected void SetStyle(ControlStyles flag, bool value);
        protected void SetTopLevel(bool value);
        internal void SetTopLevelInternal(bool value);
        internal static IntPtr SetUpPalette(IntPtr dc, bool force, bool realizePalette);
        protected virtual void SetVisibleCore(bool value);
        private void SetWindowFont();
        private void SetWindowStyle(int flag, bool value);
        internal virtual bool ShouldPerformContainerValidation();
        private bool ShouldSerializeAccessibleName();
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal virtual bool ShouldSerializeBackColor();
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal virtual bool ShouldSerializeCursor();
        [EditorBrowsable(EditorBrowsableState.Never)]
        private bool ShouldSerializeEnabled();
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal virtual bool ShouldSerializeFont();
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal virtual bool ShouldSerializeForeColor();
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal virtual bool ShouldSerializeImeMode();
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal bool ShouldSerializeMargin();
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal virtual bool ShouldSerializeMaximumSize();
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal virtual bool ShouldSerializeMinimumSize();
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal bool ShouldSerializePadding();
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal virtual bool ShouldSerializeRightToLeft();
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal virtual bool ShouldSerializeSize();
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal virtual bool ShouldSerializeText();
        [EditorBrowsable(EditorBrowsableState.Never)]
        private bool ShouldSerializeVisible();
        public void Show();
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual Size SizeFromClientSize(Size clientSize);
        internal Size SizeFromClientSize(int width, int height);
        public void SuspendLayout();
        void IDropTarget.OnDragDrop(DragEventArgs drgEvent);
        void IDropTarget.OnDragEnter(DragEventArgs drgEvent);
        void IDropTarget.OnDragLeave(EventArgs e);
        void IDropTarget.OnDragOver(DragEventArgs drgEvent);
        void ISupportOleDropSource.OnGiveFeedback(GiveFeedbackEventArgs giveFeedbackEventArgs);
        void ISupportOleDropSource.OnQueryContinueDrag(QueryContinueDragEventArgs queryContinueDragEventArgs);
        void IArrangedElement.PerformLayout(IArrangedElement affectedElement, string affectedProperty);
        void IArrangedElement.SetBounds(Rectangle bounds, BoundsSpecified specified);
        int UnsafeNativeMethods.IOleControl.FreezeEvents(int bFreeze);
        int UnsafeNativeMethods.IOleControl.GetControlInfo(NativeMethods.tagCONTROLINFO pCI);
        int UnsafeNativeMethods.IOleControl.OnAmbientPropertyChange(int dispID);
        int UnsafeNativeMethods.IOleControl.OnMnemonic(ref NativeMethods.MSG pMsg);
        void UnsafeNativeMethods.IOleInPlaceActiveObject.ContextSensitiveHelp(int fEnterMode);
        void UnsafeNativeMethods.IOleInPlaceActiveObject.EnableModeless(int fEnable);
        int UnsafeNativeMethods.IOleInPlaceActiveObject.GetWindow(out IntPtr hwnd);
        void UnsafeNativeMethods.IOleInPlaceActiveObject.OnDocWindowActivate(int fActivate);
        void UnsafeNativeMethods.IOleInPlaceActiveObject.OnFrameWindowActivate(bool fActivate);
        void UnsafeNativeMethods.IOleInPlaceActiveObject.ResizeBorder(NativeMethods.COMRECT prcBorder, UnsafeNativeMethods.IOleInPlaceUIWindow pUIWindow, bool fFrameWindow);
        int UnsafeNativeMethods.IOleInPlaceActiveObject.TranslateAccelerator(ref NativeMethods.MSG lpmsg);
        void UnsafeNativeMethods.IOleInPlaceObject.ContextSensitiveHelp(int fEnterMode);
        int UnsafeNativeMethods.IOleInPlaceObject.GetWindow(out IntPtr hwnd);
        void UnsafeNativeMethods.IOleInPlaceObject.InPlaceDeactivate();
        void UnsafeNativeMethods.IOleInPlaceObject.ReactivateAndUndo();
        void UnsafeNativeMethods.IOleInPlaceObject.SetObjectRects(NativeMethods.COMRECT lprcPosRect, NativeMethods.COMRECT lprcClipRect);
        int UnsafeNativeMethods.IOleInPlaceObject.UIDeactivate();
        int UnsafeNativeMethods.IOleObject.Advise(IAdviseSink pAdvSink, out int cookie);
        int UnsafeNativeMethods.IOleObject.Close(int dwSaveOption);
        int UnsafeNativeMethods.IOleObject.DoVerb(int iVerb, IntPtr lpmsg, UnsafeNativeMethods.IOleClientSite pActiveSite, int lindex, IntPtr hwndParent, NativeMethods.COMRECT lprcPosRect);
        int UnsafeNativeMethods.IOleObject.EnumAdvise(out IEnumSTATDATA e);
        int UnsafeNativeMethods.IOleObject.EnumVerbs(out UnsafeNativeMethods.IEnumOLEVERB e);
        UnsafeNativeMethods.IOleClientSite UnsafeNativeMethods.IOleObject.GetClientSite();
        int UnsafeNativeMethods.IOleObject.GetClipboardData(int dwReserved, out IDataObject data);
        int UnsafeNativeMethods.IOleObject.GetExtent(int dwDrawAspect, NativeMethods.tagSIZEL pSizel);
        int UnsafeNativeMethods.IOleObject.GetMiscStatus(int dwAspect, out int cookie);
        int UnsafeNativeMethods.IOleObject.GetMoniker(int dwAssign, int dwWhichMoniker, out object moniker);
        int UnsafeNativeMethods.IOleObject.GetUserClassID(ref Guid pClsid);
        int UnsafeNativeMethods.IOleObject.GetUserType(int dwFormOfType, out string userType);
        int UnsafeNativeMethods.IOleObject.InitFromData(IDataObject pDataObject, int fCreation, int dwReserved);
        int UnsafeNativeMethods.IOleObject.IsUpToDate();
        int UnsafeNativeMethods.IOleObject.OleUpdate();
        int UnsafeNativeMethods.IOleObject.SetClientSite(UnsafeNativeMethods.IOleClientSite pClientSite);
        int UnsafeNativeMethods.IOleObject.SetColorScheme(NativeMethods.tagLOGPALETTE pLogpal);
        int UnsafeNativeMethods.IOleObject.SetExtent(int dwDrawAspect, NativeMethods.tagSIZEL pSizel);
        int UnsafeNativeMethods.IOleObject.SetHostNames(string szContainerApp, string szContainerObj);
        int UnsafeNativeMethods.IOleObject.SetMoniker(int dwWhichMoniker, object pmk);
        int UnsafeNativeMethods.IOleObject.Unadvise(int dwConnection);
        void UnsafeNativeMethods.IOleWindow.ContextSensitiveHelp(int fEnterMode);
        int UnsafeNativeMethods.IOleWindow.GetWindow(out IntPtr hwnd);
        void UnsafeNativeMethods.IPersist.GetClassID(out Guid pClassID);
        void UnsafeNativeMethods.IPersistPropertyBag.GetClassID(out Guid pClassID);
        void UnsafeNativeMethods.IPersistPropertyBag.InitNew();
        void UnsafeNativeMethods.IPersistPropertyBag.Load(UnsafeNativeMethods.IPropertyBag pPropBag, UnsafeNativeMethods.IErrorLog pErrorLog);
        void UnsafeNativeMethods.IPersistPropertyBag.Save(UnsafeNativeMethods.IPropertyBag pPropBag, bool fClearDirty, bool fSaveAllProperties);
        void UnsafeNativeMethods.IPersistStorage.GetClassID(out Guid pClassID);
        void UnsafeNativeMethods.IPersistStorage.HandsOffStorage();
        void UnsafeNativeMethods.IPersistStorage.InitNew(UnsafeNativeMethods.IStorage pstg);
        int UnsafeNativeMethods.IPersistStorage.IsDirty();
        int UnsafeNativeMethods.IPersistStorage.Load(UnsafeNativeMethods.IStorage pstg);
        void UnsafeNativeMethods.IPersistStorage.Save(UnsafeNativeMethods.IStorage pstg, bool fSameAsLoad);
        void UnsafeNativeMethods.IPersistStorage.SaveCompleted(UnsafeNativeMethods.IStorage pStgNew);
        void UnsafeNativeMethods.IPersistStreamInit.GetClassID(out Guid pClassID);
        void UnsafeNativeMethods.IPersistStreamInit.GetSizeMax(long pcbSize);
        void UnsafeNativeMethods.IPersistStreamInit.InitNew();
        int UnsafeNativeMethods.IPersistStreamInit.IsDirty();
        void UnsafeNativeMethods.IPersistStreamInit.Load(UnsafeNativeMethods.IStream pstm);
        void UnsafeNativeMethods.IPersistStreamInit.Save(UnsafeNativeMethods.IStream pstm, bool fClearDirty);
        void UnsafeNativeMethods.IQuickActivate.GetContentExtent(NativeMethods.tagSIZEL pSizel);
        void UnsafeNativeMethods.IQuickActivate.QuickActivate(UnsafeNativeMethods.tagQACONTAINER pQaContainer, UnsafeNativeMethods.tagQACONTROL pQaControl);
        void UnsafeNativeMethods.IQuickActivate.SetContentExtent(NativeMethods.tagSIZEL pSizel);
        int UnsafeNativeMethods.IViewObject.Draw(int dwDrawAspect, int lindex, IntPtr pvAspect, NativeMethods.tagDVTARGETDEVICE ptd, IntPtr hdcTargetDev, IntPtr hdcDraw, NativeMethods.COMRECT lprcBounds, NativeMethods.COMRECT lprcWBounds, IntPtr pfnContinue, int dwContinue);
        int UnsafeNativeMethods.IViewObject.Freeze(int dwDrawAspect, int lindex, IntPtr pvAspect, IntPtr pdwFreeze);
        void UnsafeNativeMethods.IViewObject.GetAdvise(int[] paspects, int[] padvf, IAdviseSink[] pAdvSink);
        int UnsafeNativeMethods.IViewObject.GetColorSet(int dwDrawAspect, int lindex, IntPtr pvAspect, NativeMethods.tagDVTARGETDEVICE ptd, IntPtr hicTargetDev, NativeMethods.tagLOGPALETTE ppColorSet);
        void UnsafeNativeMethods.IViewObject.SetAdvise(int aspects, int advf, IAdviseSink pAdvSink);
        int UnsafeNativeMethods.IViewObject.Unfreeze(int dwFreeze);
        void UnsafeNativeMethods.IViewObject2.Draw(int dwDrawAspect, int lindex, IntPtr pvAspect, NativeMethods.tagDVTARGETDEVICE ptd, IntPtr hdcTargetDev, IntPtr hdcDraw, NativeMethods.COMRECT lprcBounds, NativeMethods.COMRECT lprcWBounds, IntPtr pfnContinue, int dwContinue);
        int UnsafeNativeMethods.IViewObject2.Freeze(int dwDrawAspect, int lindex, IntPtr pvAspect, IntPtr pdwFreeze);
        void UnsafeNativeMethods.IViewObject2.GetAdvise(int[] paspects, int[] padvf, IAdviseSink[] pAdvSink);
        int UnsafeNativeMethods.IViewObject2.GetColorSet(int dwDrawAspect, int lindex, IntPtr pvAspect, NativeMethods.tagDVTARGETDEVICE ptd, IntPtr hicTargetDev, NativeMethods.tagLOGPALETTE ppColorSet);
        void UnsafeNativeMethods.IViewObject2.GetExtent(int dwDrawAspect, int lindex, NativeMethods.tagDVTARGETDEVICE ptd, NativeMethods.tagSIZEL lpsizel);
        void UnsafeNativeMethods.IViewObject2.SetAdvise(int aspects, int advf, IAdviseSink pAdvSink);
        int UnsafeNativeMethods.IViewObject2.Unfreeze(int dwFreeze);
        private void UnhookMouseEvent();
        public void Update();
        private void UpdateBindings();
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected internal void UpdateBounds();
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected void UpdateBounds(int x, int y, int width, int height);
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected void UpdateBounds(int x, int y, int width, int height, int clientWidth, int clientHeight);
        private void UpdateChildControlIndex(Control ctl);
        private void UpdateChildZOrder(Control ctl);
        internal void UpdateImeContextMode();
        private void UpdateReflectParent(bool findNewParent);
        private void UpdateRoot();
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected void UpdateStyles();
        internal virtual void UpdateStylesCore();
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected void UpdateZOrder();
        private void UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs pref);
        internal bool ValidateActiveControl(out bool validatedControlAllowsFocusChange);
        private void VerifyImeModeChanged(ImeMode oldMode, ImeMode newMode);
        internal void VerifyImeRestrictedModeChanged();
        private void WaitForWaitHandle(WaitHandle waitHandle);
        internal void WindowAssignHandle(IntPtr handle, bool value);
        internal void WindowReleaseHandle();
        private void WmCaptureChanged(ref Message m);
        private void WmClose(ref Message m);
        private void WmCommand(ref Message m);
        internal virtual void WmContextMenu(ref Message m);
        internal void WmContextMenu(ref Message m, Control sourceControl);
        private void WmCreate(ref Message m);
        private void WmCtlColorControl(ref Message m);
        private void WmDestroy(ref Message m);
        private void WmDisplayChange(ref Message m);
        private void WmDpiChangedAfterParent(ref Message m);
        private void WmDpiChangedBeforeParent(ref Message m);
        private void WmDrawItem(ref Message m);
        private void WmDrawItemMenuItem(ref Message m);
        private void WmEraseBkgnd(ref Message m);
        private void WmExitMenuLoop(ref Message m);
        private void WmGetControlName(ref Message m);
        private void WmGetControlType(ref Message m);
        private void WmGetObject(ref Message m);
        private void WmHelp(ref Message m);
        private void WmImeChar(ref Message m);
        private void WmImeEndComposition(ref Message m);
        private void WmImeKillFocus();
        private void WmImeNotify(ref Message m);
        internal void WmImeSetFocus();
        private void WmImeStartComposition(ref Message m);
        private void WmInitMenuPopup(ref Message m);
        private void WmInputLangChange(ref Message m);
        private void WmInputLangChangeRequest(ref Message m);
        private void WmKeyChar(ref Message m);
        private void WmKillFocus(ref Message m);
        private void WmMeasureItem(ref Message m);
        private void WmMenuChar(ref Message m);
        private void WmMenuSelect(ref Message m);
        private void WmMouseDown(ref Message m, MouseButtons button, int clicks);
        private void WmMouseEnter(ref Message m);
        private void WmMouseHover(ref Message m);
        private void WmMouseLeave(ref Message m);
        private void WmMouseMove(ref Message m);
        private void WmMouseUp(ref Message m, MouseButtons button, int clicks);
        private void WmMouseWheel(ref Message m);
        private void WmMove(ref Message m);
        private void WmNotify(ref Message m);
        private void WmNotifyFormat(ref Message m);
        private void WmOwnerDraw(ref Message m);
        private void WmPaint(ref Message m);
        private void WmParentNotify(ref Message m);
        private void WmPrintClient(ref Message m);
        private void WmQueryNewPalette(ref Message m);
        private void WmSetCursor(ref Message m);
        private void WmSetFocus(ref Message m);
        private void WmShowWindow(ref Message m);
        private void WmUpdateUIState(ref Message m);
        private void WmWindowPosChanged(ref Message m);
        private void WmWindowPosChanging(ref Message m);
        [SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.UnmanagedCode), SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected virtual void WndProc(ref Message m);
        private void WndProcException(Exception e);

        // Properties
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ControlAccessibilityObjectDescr")]
        public AccessibleObject AccessibilityObject { get; }
        [SRCategory("CatAccessibility"), Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ControlAccessibleDefaultActionDescr")]
        public string AccessibleDefaultActionDescription { get; set; }
        [SRCategory("CatAccessibility"), DefaultValue((string)null), Localizable(true), SRDescription("ControlAccessibleDescriptionDescr")]
        public string AccessibleDescription { get; set; }
        [SRCategory("CatAccessibility"), DefaultValue((string)null), Localizable(true), SRDescription("ControlAccessibleNameDescr")]
        public string AccessibleName { get; set; }
        [SRCategory("CatAccessibility"), DefaultValue(-1), SRDescription("ControlAccessibleRoleDescr")]
        public AccessibleRole AccessibleRole { get; set; }
        private Color ActiveXAmbientBackColor { get; }
        private Font ActiveXAmbientFont { get; }
        private Color ActiveXAmbientForeColor { get; }
        private bool ActiveXEventsFrozen { get; }
        private IntPtr ActiveXHWNDParent { get; }
        private ActiveXImpl ActiveXInstance { get; }
        [SRCategory("CatBehavior"), DefaultValue(false), SRDescription("ControlAllowDropDescr")]
        public virtual bool AllowDrop { get; set; }
        private AmbientProperties AmbientPropertiesService { get; }
        [SRCategory("CatLayout"), Localizable(true), DefaultValue(5), SRDescription("ControlAnchorDescr"), RefreshProperties(RefreshProperties.Repaint)]
        public virtual AnchorStyles Anchor { get; set; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DefaultValue(typeof(Point), "0, 0")]
        public virtual Point AutoScrollOffset { get; set; }
        [SRCategory("CatLayout"), RefreshProperties(RefreshProperties.All), Localizable(true), DefaultValue(false), SRDescription("ControlAutoSizeDescr"), Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool AutoSize { get; set; }
        [SRCategory("CatAppearance"), DispId(-501), SRDescription("ControlBackColorDescr")]
        public virtual Color BackColor { get; set; }
        internal IntPtr BackColorBrush { get; }
        [SRCategory("CatAppearance"), DefaultValue((string)null), Localizable(true), SRDescription("ControlBackgroundImageDescr")]
        public virtual Image BackgroundImage { get; set; }
        [SRCategory("CatAppearance"), DefaultValue(1), Localizable(true), SRDescription("ControlBackgroundImageLayoutDescr")]
        public virtual ImageLayout BackgroundImageLayout { get; set; }
        internal bool BecomingActiveControl { get; set; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ControlBindingContextDescr")]
        public virtual BindingContext BindingContext { get; set; }
        internal BindingContext BindingContextInternal { get; set; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ControlBottomDescr"), SRCategory("CatLayout")]
        public int Bottom { get; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ControlBoundsDescr"), SRCategory("CatLayout")]
        public Rectangle Bounds { get; set; }
        private BufferedGraphicsContext BufferContext { get; }
        internal ImeMode CachedImeMode { get; set; }
        internal bool CacheTextInternal { get; set; }
        internal virtual bool CanAccessProperties { get; }
        protected virtual bool CanEnableIme { get; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRCategory("CatFocus"), SRDescription("ControlCanFocusDescr")]
        public bool CanFocus { get; }
        protected override bool CanRaiseEvents { get; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRCategory("CatFocus"), SRDescription("ControlCanSelectDescr")]
        public bool CanSelect { get; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRCategory("CatFocus"), SRDescription("ControlCaptureDescr")]
        public bool Capture { get; set; }
        internal bool CaptureInternal { get; set; }
        [SRCategory("CatFocus"), DefaultValue(true), SRDescription("ControlCausesValidationDescr")]
        public bool CausesValidation { get; set; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), SRDescription("ControlCheckForIllegalCrossThreadCalls"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static bool CheckForIllegalCrossThreadCalls { get; set; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRCategory("CatLayout"), SRDescription("ControlClientRectangleDescr")]
        public Rectangle ClientRectangle { get; }
        [SRCategory("CatLayout"), Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ControlClientSizeDescr")]
        public Size ClientSize { get; set; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Description("ControlCompanyNameDescr")]
        public string CompanyName { get; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ControlContainsFocusDescr")]
        public bool ContainsFocus { get; }
        [SRCategory("CatBehavior"), DefaultValue((string)null), SRDescription("ControlContextMenuDescr"), Browsable(false)]
        public virtual ContextMenu ContextMenu { get; set; }
        [SRCategory("CatBehavior"), DefaultValue((string)null), SRDescription("ControlContextMenuDescr")]
        public virtual ContextMenuStrip ContextMenuStrip { get; set; }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), SRDescription("ControlControlsDescr")]
        public ControlCollection Controls { get; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ControlCreatedDescr")]
        public bool Created { get; }
        protected virtual CreateParams CreateParams { [SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.UnmanagedCode), SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)] get; }
        internal int CreateThreadId { get; }
        internal ImeMode CurrentImeContextMode { get; }
        [SRCategory("CatAppearance"), SRDescription("ControlCursorDescr"), AmbientValue((string)null)]
        public virtual Cursor Cursor { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), SRCategory("CatData"), SRDescription("ControlBindingsDescr"), RefreshProperties(RefreshProperties.All), ParenthesizePropertyName(true)]
        public ControlBindingsCollection DataBindings { get; }
        public static Color DefaultBackColor { get; }
        protected virtual Cursor DefaultCursor { get; }
        public static Font DefaultFont { get; }
        public static Color DefaultForeColor { get; }
        protected virtual ImeMode DefaultImeMode { get; }
        protected virtual Padding DefaultMargin { get; }
        protected virtual Size DefaultMaximumSize { get; }
        protected virtual Size DefaultMinimumSize { get; }
        protected virtual Padding DefaultPadding { get; }
        private RightToLeft DefaultRightToLeft { get; }
        protected virtual Size DefaultSize { get; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Always), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int DeviceDpi { get; }
        internal Color DisabledColor { get; }
        internal int DisableImeModeChangedCount { get; set; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ControlDisplayRectangleDescr")]
        public virtual Rectangle DisplayRectangle { get; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ControlDisposingDescr")]
        public bool Disposing { get; }
        [SRCategory("CatLayout"), Localizable(true), RefreshProperties(RefreshProperties.Repaint), DefaultValue(0), SRDescription("ControlDockDescr")]
        public virtual DockStyle Dock { get; set; }
        [SRCategory("CatBehavior"), SRDescription("ControlDoubleBufferedDescr")]
        protected virtual bool DoubleBuffered { get; set; }
        private bool DoubleBufferingEnabled { get; }
        [SRCategory("CatBehavior"), Localizable(true), DispId(-514), SRDescription("ControlEnabledDescr")]
        public bool Enabled { get; set; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ControlFocusedDescr")]
        public virtual bool Focused { get; }
        [SRCategory("CatAppearance"), Localizable(true), DispId(-512), AmbientValue((string)null), SRDescription("ControlFontDescr")]
        public virtual Font Font { [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "", MarshalTypeRef = typeof(ActiveXFontMarshaler), MarshalCookie = "")] get; [param: MarshalAs(UnmanagedType.CustomMarshaler, MarshalType = "", MarshalTypeRef = typeof(ActiveXFontMarshaler), MarshalCookie = "")] set; }
        internal IntPtr FontHandle { get; }
        protected int FontHeight { get; set; }
        [SRCategory("CatAppearance"), DispId(-513), SRDescription("ControlForeColorDescr")]
        public virtual Color ForeColor { get; set; }
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), DispId(-515), SRDescription("ControlHandleDescr")]
        public IntPtr Handle { get; }
        internal IntPtr HandleInternal { get; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ControlHasChildrenDescr")]
        public bool HasChildren { get; }
        internal virtual bool HasMenu { get; }
        [SRCategory("CatLayout"), Browsable(false), EditorBrowsable(EditorBrowsableState.Always), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ControlHeightDescr")]
        public int Height { get; set; }
        internal bool HostedInWin32DialogManager { get; }
        private static bool IgnoreWmImeNotify { get; set; }
        [SRCategory("CatBehavior"), Localizable(true), AmbientValue(-1), SRDescription("ControlIMEModeDescr")]
        public ImeMode ImeMode { get; set; }
        protected virtual ImeMode ImeModeBase { get; set; }
        private bool ImeSupported { get; }
        internal int ImeWmCharsToIgnore { get; set; }
        internal IntPtr InternalHandle { get; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ControlInvokeRequiredDescr")]
        public bool InvokeRequired { get; }
        [SRCategory("CatBehavior"), Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ControlIsAccessibleDescr")]
        public bool IsAccessible { get; set; }
        internal bool IsActiveX { get; }
        internal virtual bool IsContainerControl { get; }
        internal bool IsCurrentlyBeingScaled { get; private set; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ControlDisposedDescr")]
        public bool IsDisposed { get; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ControlHandleCreatedDescr")]
        public bool IsHandleCreated { get; }
        internal bool IsIEParent { get; }
        internal bool IsLayoutSuspended { get; }
        [SRCategory("CatLayout"), Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("IsMirroredDescr")]
        public bool IsMirrored { get; }
        internal virtual bool IsMnemonicsListenerAxSourced { get; }
        internal bool IsTopMdiWindowClosing { get; set; }
        internal bool IsWindowObscured { get; }
        private bool LastCanEnableIme { get; set; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
        public virtual LayoutEngine LayoutEngine { get; }
        [SRCategory("CatLayout"), Browsable(false), EditorBrowsable(EditorBrowsableState.Always), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ControlLeftDescr")]
        public int Left { get; set; }
        [SRCategory("CatLayout"), Localizable(true), SRDescription("ControlLocationDescr")]
        public Point Location { get; set; }
        [SRDescription("ControlMarginDescr"), SRCategory("CatLayout"), Localizable(true)]
        public Padding Margin { get; set; }
        [SRCategory("CatLayout"), Localizable(true), SRDescription("ControlMaximumSizeDescr"), AmbientValue(typeof(Size), "0, 0")]
        public virtual Size MaximumSize { get; set; }
        [SRCategory("CatLayout"), Localizable(true), SRDescription("ControlMinimumSizeDescr")]
        public virtual Size MinimumSize { get; set; }
        public static Keys ModifierKeys { get; }
        public static MouseButtons MouseButtons { get; }
        public static Point MousePosition { get; }
        [Browsable(false)]
        public string Name { get; set; }
        private AccessibleObject NcAccessibilityObject { get; }
        [SRDescription("ControlPaddingDescr"), SRCategory("CatLayout"), Localizable(true)]
        public Padding Padding { get; set; }
        [SRCategory("CatBehavior"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ControlParentDescr")]
        public Control Parent { get; set; }
        internal ContainerControl ParentContainerControl { get; }
        internal virtual Control ParentInternal { get; set; }
        [Browsable(false)]
        public Size PreferredSize { get; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ControlProductNameDescr")]
        public string ProductName { get; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ControlProductVersionDescr")]
        public string ProductVersion { get; }
        protected static ImeMode PropagatingImeMode { get; private set; }
        internal PropertyStore Properties { get; }
        internal Color RawBackColor { get; }
        [SRCategory("CatBehavior"), Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ControlRecreatingHandleDescr")]
        public bool RecreatingHandle { get; }
        private Control ReflectParent { get; set; }
        [SRCategory("CatLayout"), Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ControlRegionDescr")]
        public Region Region { get; set; }
        [Obsolete("This property has been deprecated. Please use RightToLeft instead. http://go.microsoft.com/fwlink/?linkid=14202")]
        protected internal bool RenderRightToLeft { get; }
        internal virtual bool RenderTransparencyWithVisualStyles { get; }
        internal bool RenderTransparent { get; }
        internal BoundsSpecified RequiredScaling { get; set; }
        internal bool RequiredScalingEnabled { get; set; }
        [SRDescription("ControlResizeRedrawDescr")]
        protected bool ResizeRedraw { get; set; }
        [SRCategory("CatLayout"), Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ControlRightDescr")]
        public int Right { get; }
        [SRCategory("CatAppearance"), Localizable(true), AmbientValue(2), SRDescription("ControlRightToLeftDescr")]
        public virtual RightToLeft RightToLeft { get; set; }
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual bool ScaleChildren { get; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal bool ShouldAutoValidate { get; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected internal virtual bool ShowFocusCues { get; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected internal virtual bool ShowKeyboardCues { get; }
        internal virtual int ShowParams { get; }
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public override ISite Site { get; set; }
        [SRCategory("CatLayout"), Localizable(true), SRDescription("ControlSizeDescr")]
        public Size Size { get; set; }
        internal virtual bool SupportsUseCompatibleTextRendering { get; }
        ArrangedElementCollection IArrangedElement.Children { get; }
        IArrangedElement IArrangedElement.Container { get; }
        bool IArrangedElement.ParticipatesInLayout { get; }
        PropertyStore IArrangedElement.Properties { get; }
        [SRCategory("CatBehavior"), Localizable(true), MergableProperty(false), SRDescription("ControlTabIndexDescr")]
        public int TabIndex { get; set; }
        [SRCategory("CatBehavior"), DefaultValue(true), DispId(-516), SRDescription("ControlTabStopDescr")]
        public bool TabStop { get; set; }
        internal bool TabStopInternal { get; set; }
        [SRCategory("CatData"), Localizable(false), Bindable(true), SRDescription("ControlTagDescr"), DefaultValue((string)null), TypeConverter(typeof(StringConverter))]
        public object Tag { get; set; }
        [SRCategory("CatAppearance"), Localizable(true), Bindable(true), DispId(-517), SRDescription("ControlTextDescr")]
        public virtual string Text { get; set; }
        [SRCategory("CatLayout"), Browsable(false), EditorBrowsable(EditorBrowsableState.Always), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ControlTopDescr")]
        public int Top { get; set; }
        [SRCategory("CatBehavior"), Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ControlTopLevelControlDescr")]
        public Control TopLevelControl { get; }
        internal Control TopLevelControlInternal { get; }
        internal Control TopMostParent { get; }
        internal bool UseCompatibleTextRenderingInt { get; set; }
        [DefaultValue(false), EditorBrowsable(EditorBrowsableState.Always), Browsable(true), SRCategory("CatAppearance"), SRDescription("ControlUseWaitCursorDescr")]
        public bool UseWaitCursor { get; set; }
        internal bool ValidationCancelled { get; set; }
        private ControlVersionInfo VersionInfo { get; }
        [SRCategory("CatBehavior"), Localizable(true), SRDescription("ControlVisibleDescr")]
        public bool Visible { get; set; }
        [SRCategory("CatLayout"), Browsable(false), EditorBrowsable(EditorBrowsableState.Always), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ControlWidthDescr")]
        public int Width { get; set; }
        private int WindowExStyle { get; set; }
        internal int WindowStyle { get; set; }
        [SRCategory("CatBehavior"), Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("ControlWindowTargetDescr")]
        public IWindowTarget WindowTarget { [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)] get; [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)] set; }
        internal virtual string WindowText { get; set; }

        // Nested Types
        private class ActiveXFontMarshaler : ICustomMarshaler
        {
            // Fields
            private static Control.ActiveXFontMarshaler instance;

            // Methods
            public ActiveXFontMarshaler();
            public void CleanUpManagedData(object obj);
            public void CleanUpNativeData(IntPtr pObj);
            internal static ICustomMarshaler GetInstance(string cookie);
            public int GetNativeDataSize();
            public IntPtr MarshalManagedToNative(object obj);
            public object MarshalNativeToManaged(IntPtr pObj);
        }

        private class ActiveXImpl : MarshalByRefObject, IWindowTarget
        {
            // Fields
            private short accelCount;
            private IntPtr accelTable;
            private BitVector32 activeXState;
            private static readonly int adjustingRect;
            private NativeMethods.COMRECT adjustRect;
            private ArrayList adviseList;
            private Control.AmbientProperty[] ambientProperties;
            private static NativeMethods.tagOLEVERB[] axVerbs;
            private static readonly int changingExtents;
            private static bool checkedIE;
            private UnsafeNativeMethods.IOleClientSite clientSite;
            private IntPtr clipRegion;
            private Control control;
            private IWindowTarget controlWindowTarget;
            private static readonly int eventsFrozen;
            private static int globalActiveXCount;
            private static readonly int hiMetricPerInch;
            private IntPtr hwndParent;
            private static readonly int inPlaceActive;
            private UnsafeNativeMethods.IOleInPlaceFrame inPlaceFrame;
            private UnsafeNativeMethods.IOleInPlaceUIWindow inPlaceUiWindow;
            private static readonly int inPlaceVisible;
            private static readonly int isDirty;
            private static bool isIE;
            private static Point logPixels;
            private static readonly int saving;
            private static readonly int uiActive;
            private static readonly int uiDead;
            private static readonly int viewAdviseOnlyOnce;
            private static readonly int viewAdvisePrimeFirst;
            private IAdviseSink viewAdviseSink;

            // Methods
            static ActiveXImpl();
            internal ActiveXImpl(Control control);
            internal int Advise(IAdviseSink pAdvSink);
            private void CallParentPropertyChanged(Control control, string propName);
            internal void Close(int dwSaveOption);
            internal void DoVerb(int iVerb, IntPtr lpmsg, UnsafeNativeMethods.IOleClientSite pActiveSite, int lindex, IntPtr hwndParent, NativeMethods.COMRECT lprcPosRect);
            internal void Draw(int dwDrawAspect, int lindex, IntPtr pvAspect, NativeMethods.tagDVTARGETDEVICE ptd, IntPtr hdcTargetDev, IntPtr hdcDraw, NativeMethods.COMRECT prcBounds, NativeMethods.COMRECT lprcWBounds, IntPtr pfnContinue, int dwContinue);
            internal static int EnumVerbs(out UnsafeNativeMethods.IEnumOLEVERB e);
            private static byte[] FromBase64WrappedString(string text);
            internal void GetAdvise(int[] paspects, int[] padvf, IAdviseSink[] pAdvSink);
            private bool GetAmbientProperty(int dispid, ref object obj);
            internal UnsafeNativeMethods.IOleClientSite GetClientSite();
            [SecurityPermission(SecurityAction.Assert, Flags = SecurityPermissionFlag.UnmanagedCode)]
            internal int GetControlInfo(NativeMethods.tagCONTROLINFO pCI);
            private static Type GetDefaultEventsInterface(Type controlType);
            internal void GetExtent(int dwDrawAspect, NativeMethods.tagSIZEL pSizel);
            private void GetMnemonicList(Control control, ArrayList mnemonicList);
            private string GetStreamName();
            internal int GetWindow(out IntPtr hwnd);
            private Point HiMetricToPixel(int x, int y);
            [SecurityPermission(SecurityAction.Assert, Flags = SecurityPermissionFlag.UnmanagedCode)]
            internal void InPlaceActivate(int verb);
            internal void InPlaceDeactivate();
            internal int IsDirty();
            private bool IsResourceProp(PropertyDescriptor prop);
            internal void Load(UnsafeNativeMethods.IStorage stg);
            internal void Load(UnsafeNativeMethods.IStream stream);
            internal void Load(UnsafeNativeMethods.IPropertyBag pPropBag, UnsafeNativeMethods.IErrorLog pErrorLog);
            private Control.AmbientProperty LookupAmbient(int dispid);
            internal IntPtr MergeRegion(IntPtr region);
            internal void OnAmbientPropertyChange(int dispID);
            internal void OnDocWindowActivate(int fActivate);
            internal void OnFocus(bool focus);
            private Point PixelToHiMetric(int x, int y);
            internal void QuickActivate(UnsafeNativeMethods.tagQACONTAINER pQaContainer, UnsafeNativeMethods.tagQACONTROL pQaControl);
            internal void Save(UnsafeNativeMethods.IStorage stg, bool fSameAsLoad);
            internal void Save(UnsafeNativeMethods.IStream stream, bool fClearDirty);
            [SecurityPermission(SecurityAction.Assert, Flags = SecurityPermissionFlag.UnmanagedCode)]
            internal void Save(UnsafeNativeMethods.IPropertyBag pPropBag, bool fClearDirty, bool fSaveAllProperties);
            private void SendOnSave();
            internal void SetAdvise(int aspects, int advf, IAdviseSink pAdvSink);
            internal void SetClientSite(UnsafeNativeMethods.IOleClientSite value);
            [SecurityPermission(SecurityAction.Assert, Flags = SecurityPermissionFlag.UnmanagedCode)]
            internal void SetExtent(int dwDrawAspect, NativeMethods.tagSIZEL pSizel);
            private void SetInPlaceVisible(bool visible);
            internal void SetObjectRects(NativeMethods.COMRECT lprcPosRect, NativeMethods.COMRECT lprcClipRect);
            void IWindowTarget.OnHandleChange(IntPtr newHandle);
            void IWindowTarget.OnMessage(ref Message m);
            internal static void ThrowHr(int hr);
            internal int TranslateAccelerator(ref NativeMethods.MSG lpmsg);
            internal int UIDeactivate();
            internal void Unadvise(int dwConnection);
            internal void UpdateAccelTable();
            internal void UpdateBounds(ref int x, ref int y, ref int width, ref int height, int flags);
            private void ViewChanged();
            internal void ViewChangedInternal();

            // Properties
            [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            internal Color AmbientBackColor { get; }
            [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            internal Font AmbientFont { get; }
            [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            internal Color AmbientForeColor { get; }
            [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            internal bool EventsFrozen { get; set; }
            internal IntPtr HWNDParent { get; }
            internal bool IsIE { [SecurityPermission(SecurityAction.Assert, Flags = SecurityPermissionFlag.UnmanagedCode)] get; }
            private Point LogPixels { get; }

            // Nested Types
            internal static class AdviseHelper
            {
                // Methods
                public static bool AdviseConnectionPoint(object connectionPoint, object sink, Type eventInterface, out int cookie);
                internal static bool AdviseConnectionPoint(ComConnectionPointContainer cpc, object sink, Type eventInterface, out int cookie);

                // Nested Types
                internal sealed class ComConnectionPoint : Control.ActiveXImpl.AdviseHelper.SafeIUnknown
                {
                    // Fields
                    private VTABLE vtbl;

                    // Methods
                    public ComConnectionPoint(object obj, bool addRefIntPtr);
                    public bool Advise(IntPtr punkEventSink, out int cookie);

                    // Nested Types
                    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
                    private delegate int AdviseD(IntPtr This, IntPtr punkEventSink, out int cookie);

                    [StructLayout(LayoutKind.Sequential)]
                    private class VTABLE
                    {
                        public IntPtr QueryInterfacePtr;
                        public IntPtr AddRefPtr;
                        public IntPtr ReleasePtr;
                        public IntPtr GetConnectionInterfacePtr;
                        public IntPtr GetConnectionPointContainterPtr;
                        public IntPtr AdvisePtr;
                        public IntPtr UnadvisePtr;
                        public IntPtr EnumConnectionsPtr;
                        public VTABLE();
                    }
                }

                internal sealed class ComConnectionPointContainer : Control.ActiveXImpl.AdviseHelper.SafeIUnknown
                {
                    // Fields
                    private VTABLE vtbl;

                    // Methods
                    public ComConnectionPointContainer(object obj, bool addRefIntPtr);
                    public Control.ActiveXImpl.AdviseHelper.ComConnectionPoint FindConnectionPoint(Type eventInterface);

                    // Nested Types
                    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
                    private delegate int FindConnectionPointD(IntPtr This, ref Guid iid, out IntPtr ppv);

                    [StructLayout(LayoutKind.Sequential)]
                    private class VTABLE
                    {
                        public IntPtr QueryInterfacePtr;
                        public IntPtr AddRefPtr;
                        public IntPtr ReleasePtr;
                        public IntPtr EnumConnectionPointsPtr;
                        public IntPtr FindConnectionPointPtr;
                        public VTABLE();
                    }
                }

                internal class SafeIUnknown : SafeHandle
                {
                    // Methods
                    public SafeIUnknown(object obj, bool addRefIntPtr);
                    public SafeIUnknown(object obj, bool addRefIntPtr, Guid iid);
                    private static IntPtr InternalQueryInterface(IntPtr pUnk, ref Guid iid);
                    protected V LoadVtable<V>();
                    protected sealed override bool ReleaseHandle();

                    // Properties
                    public sealed override bool IsInvalid { get; }
                }
            }

            private class PropertyBagStream : UnsafeNativeMethods.IPropertyBag
            {
                // Fields
                private Hashtable bag;

                // Methods
                public PropertyBagStream();
                [SecurityPermission(SecurityAction.Assert, Flags = SecurityPermissionFlag.UnmanagedCode)]
                internal void Read(UnsafeNativeMethods.IStream istream);
                [SecurityPermission(SecurityAction.Assert, Flags = SecurityPermissionFlag.UnmanagedCode)]
                int UnsafeNativeMethods.IPropertyBag.Read(string pszPropName, ref object pVar, UnsafeNativeMethods.IErrorLog pErrorLog);
                [SecurityPermission(SecurityAction.Assert, Flags = SecurityPermissionFlag.UnmanagedCode)]
                int UnsafeNativeMethods.IPropertyBag.Write(string pszPropName, ref object pVar);
                [SecurityPermission(SecurityAction.Assert, Flags = SecurityPermissionFlag.UnmanagedCode)]
                internal void Write(UnsafeNativeMethods.IStream istream);
            }
        }

        private class ActiveXVerbEnum : UnsafeNativeMethods.IEnumOLEVERB
        {
            // Fields
            private int current;
            private NativeMethods.tagOLEVERB[] verbs;

            // Methods
            internal ActiveXVerbEnum(NativeMethods.tagOLEVERB[] verbs);
            public void Clone(out UnsafeNativeMethods.IEnumOLEVERB ppenum);
            public int Next(int celt, NativeMethods.tagOLEVERB rgelt, int[] pceltFetched);
            public void Reset();
            public int Skip(int celt);
        }

        private class AmbientProperty
        {
            // Fields
            private int dispID;
            private bool empty;
            private string name;
            private object value;

            // Methods
            internal AmbientProperty(string name, int dispID);
            internal void ResetValue();

            // Properties
            internal int DispID { get; }
            internal bool Empty { get; }
            internal string Name { get; }
            internal object Value { get; set; }
        }

        private class AxSourcingSite : ISite, IServiceProvider
        {
            // Fields
            private UnsafeNativeMethods.IOleClientSite clientSite;
            private IComponent component;
            private string name;
            private HtmlShimManager shimManager;

            // Methods
            internal AxSourcingSite(IComponent component, UnsafeNativeMethods.IOleClientSite clientSite, string name);
            public object GetService(Type service);

            // Properties
            public IComponent Component { get; }
            public IContainer Container { get; }
            public bool DesignMode { get; }
            public string Name { get; set; }
        }

        [ComVisible(true)]
        public class ControlAccessibleObject : AccessibleObject
        {
            // Fields
            private IntPtr handle;
            private static IntPtr oleAccAvailable;
            private Control ownerControl;

            // Methods
            static ControlAccessibleObject();
            public ControlAccessibleObject(Control ownerControl);
            internal ControlAccessibleObject(Control ownerControl, int accObjId);
            public override int GetHelpTopic(out string fileName);
            internal override bool GetSysChild(AccessibleNavigation navdir, out AccessibleObject accessibleObject);
            internal override int[] GetSysChildOrder();
            public void NotifyClients(AccessibleEvents accEvent);
            public void NotifyClients(AccessibleEvents accEvent, int childID);
            public void NotifyClients(AccessibleEvents accEvent, int objectID, int childID);
            public override string ToString();

            // Properties
            public override string DefaultAction { get; }
            public override string Description { get; }
            public IntPtr Handle { get; set; }
            public override string Help { get; }
            public override string KeyboardShortcut { get; }
            public override string Name { get; set; }
            public Control Owner { get; }
            public override AccessibleObject Parent { [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode), SecurityPermission(SecurityAction.InheritanceDemand, Flags = SecurityPermissionFlag.UnmanagedCode)] get; }
            internal Label PreviousLabel { get; }
            public override AccessibleRole Role { get; }
            internal string TextLabel { get; }
        }

        [ListBindable(false), ComVisible(false)]
        public class ControlCollection : ArrangedElementCollection, IList, ICollection, IEnumerable, ICloneable
        {
            // Fields
            private int lastAccessedIndex;
            private Control owner;

            // Methods
            public ControlCollection(Control owner);
            public virtual void Add(Control value);
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
            public virtual void AddRange(Control[] controls);
            public virtual void Clear();
            public bool Contains(Control control);
            public virtual bool ContainsKey(string key);
            public Control[] Find(string key, bool searchAllChildren);
            private ArrayList FindInternal(string key, bool searchAllChildren, Control.ControlCollection controlsToLookIn, ArrayList foundControls);
            public int GetChildIndex(Control child);
            public virtual int GetChildIndex(Control child, bool throwException);
            public override IEnumerator GetEnumerator();
            public int IndexOf(Control control);
            public virtual int IndexOfKey(string key);
            private bool IsValidIndex(int index);
            public virtual void Remove(Control value);
            public void RemoveAt(int index);
            public virtual void RemoveByKey(string key);
            public virtual void SetChildIndex(Control child, int newIndex);
            internal virtual void SetChildIndexInternal(Control child, int newIndex);
            int IList.Add(object control);
            void IList.Remove(object control);
            object ICloneable.Clone();

            // Properties
            public virtual Control this[int index] { get; }
            public virtual Control this[string key] { get; }
            public Control Owner { get; }

            // Nested Types
            private class ControlCollectionEnumerator : IEnumerator
            {
                // Fields
                private Control.ControlCollection controls;
                private int current;
                private int originalCount;

                // Methods
                public ControlCollectionEnumerator(Control.ControlCollection controls);
                public bool MoveNext();
                public void Reset();

                // Properties
                public object Current { get; }
            }
        }

        internal sealed class ControlNativeWindow : NativeWindow, IWindowTarget
        {
            // Fields
            private Control control;
            private GCHandle rootRef;
            internal IWindowTarget target;

            // Methods
            internal ControlNativeWindow(Control control);
            internal Control GetControl();
            internal void LockReference(bool locked);
            protected override void OnHandleChange();
            public void OnHandleChange(IntPtr newHandle);
            public void OnMessage(ref Message m);
            protected override void OnThreadException(Exception e);
            protected override void WndProc(ref Message m);

            // Properties
            internal IWindowTarget WindowTarget { get; set; }
        }

        private class ControlTabOrderComparer : IComparer
        {
            // Methods
            public ControlTabOrderComparer();
            int IComparer.Compare(object x, object y);
        }

        private class ControlTabOrderHolder
        {
            // Fields
            internal readonly Control control;
            internal readonly int newOrder;
            internal readonly int oldOrder;

            // Methods
            internal ControlTabOrderHolder(int oldOrder, int newOrder, Control control);
        }

        private class ControlVersionInfo
        {
            // Fields
            private string companyName;
            private Control owner;
            private string productName;
            private string productVersion;
            private FileVersionInfo versionInfo;

            // Methods
            internal ControlVersionInfo(Control owner);
            private FileVersionInfo GetFileVersionInfo();

            // Properties
            internal string CompanyName { get; }
            internal string ProductName { get; }
            internal string ProductVersion { get; }
        }

        internal sealed class FontHandleWrapper : MarshalByRefObject, IDisposable
        {
            // Fields
            private IntPtr handle;

            // Methods
            internal FontHandleWrapper(Font font);
            public void Dispose();
            private void Dispose(bool disposing);
            protected override void Finalize();

            // Properties
            internal IntPtr Handle { get; }
        }

        private class MetafileDCWrapper : IDisposable
        {
            // Fields
            private NativeMethods.RECT destRect;
            private HandleRef hBitmap;
            private HandleRef hBitmapDC;
            private HandleRef hMetafileDC;
            private HandleRef hOriginalBmp;

            // Methods
            internal MetafileDCWrapper(HandleRef hOriginalDC, Size size);
            private bool DICopy(HandleRef hdcDest, HandleRef hdcSrc, NativeMethods.RECT rect, bool bStretch);
            protected override void Finalize();
            void IDisposable.Dispose();

            // Properties
            internal IntPtr HDC { get; }
        }

        private sealed class MultithreadSafeCallScope : IDisposable
        {
            // Fields
            private bool resultedInSet;

            // Methods
            internal MultithreadSafeCallScope();
            void IDisposable.Dispose();
        }

        private sealed class PrintPaintEventArgs : PaintEventArgs
        {
            // Fields
            private Message m;

            // Methods
            internal PrintPaintEventArgs(Message m, IntPtr dc, Rectangle clipRect);

            // Properties
            internal Message Message { get; }
        }

        private class ThreadMethodEntry : IAsyncResult
        {
            // Fields
            internal object[] args;
            internal Control caller;
            internal Exception exception;
            internal ExecutionContext executionContext;
            private object invokeSyncObject;
            private bool isCompleted;
            internal Control marshaler;
            internal Delegate method;
            private ManualResetEvent resetEvent;
            internal object retVal;
            internal SynchronizationContext syncContext;
            internal bool synchronous;

            // Methods
            internal ThreadMethodEntry(Control caller, Control marshaler, Delegate method, object[] args, bool synchronous, ExecutionContext executionContext);
            internal void Complete();
            protected override void Finalize();

            // Properties
            public object AsyncState { get; }
            public WaitHandle AsyncWaitHandle { get; }
            public bool CompletedSynchronously { get; }
            public bool IsCompleted { get; }
        }

    }
}

package md50d099e9228ce1104219a6fc2ae6eaf25;


public class Profile
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("HuffmanHenryAssn4.Profile, HuffmanHenryAssn4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Profile.class, __md_methods);
	}


	public Profile () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Profile.class)
			mono.android.TypeManager.Activate ("HuffmanHenryAssn4.Profile, HuffmanHenryAssn4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}

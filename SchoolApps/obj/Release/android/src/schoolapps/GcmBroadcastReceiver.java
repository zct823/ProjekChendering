package schoolapps;


public class GcmBroadcastReceiver
	extends gcm.client.GcmBroadcastReceiverBase_1
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("SchoolApps.GcmBroadcastReceiver, SchoolApps, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", GcmBroadcastReceiver.class, __md_methods);
	}


	public GcmBroadcastReceiver () throws java.lang.Throwable
	{
		super ();
		if (getClass () == GcmBroadcastReceiver.class)
			mono.android.TypeManager.Activate ("SchoolApps.GcmBroadcastReceiver, SchoolApps, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	java.util.ArrayList refList;
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

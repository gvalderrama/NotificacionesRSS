using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	protected void OnButton1Clicked (object sender, EventArgs e)
	{
		//throw new System.NotImplementedException ();
	}
	
	protected void OnButton2Clicked (object sender, EventArgs e)
	{
		new NotificacionesRSS.historial();
		//throw new System.NotImplementedException ();
	}
	
	protected void OnButton3Clicked (object sender, EventArgs e)
	{
		new NotificacionesRSS.ajustes ();
		//throw new System.NotImplementedException ();
	}
	
	protected void OnButton7Clicked (object sender, EventArgs e)
	{
		throw new System.NotImplementedException ();
	}
}



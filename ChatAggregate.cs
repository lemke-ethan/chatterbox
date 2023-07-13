namespace chatterbox;

public interface IChatAggregateRoot
{
		void SendMessage();
		void UpdateMessage();
		void AddMedia();
		void RageQuit();

		void KickChatter();
		void InviteChatter();
		void ChangeSettings();
		void UpdatePermissions();
}


public class ChatAggregateRoot : IChatAggregateRoot
{
	public void AddMedia()
	{
		throw new NotImplementedException();
	}

	public void ChangeSettings()
	{
		throw new NotImplementedException();
	}

	public void InviteChatter()
	{
		throw new NotImplementedException();
	}

	public void KickChatter()
	{
		throw new NotImplementedException();
	}

	public void RageQuit()
	{
		throw new NotImplementedException();
	}

	public void SendMessage()
	{
		throw new NotImplementedException();
	}

	public void UpdateMessage()
	{
		throw new NotImplementedException();
	}

	public void UpdatePermissions()
	{
		throw new NotImplementedException();
	}
}
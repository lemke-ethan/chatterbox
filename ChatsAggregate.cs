namespace chatterbox;

public interface IChatsAggregateRoot
{
		void CreateChat();
		void JoinChat(int chatId, string chatterName);
		void LeaveChat(int chatId, string chatterName);
		void PinChat(int chatId);
		void UnpinChat(int chatId);
		void ArchiveChat(int chatId);
		void DeleteChat(int chatId);
}

public class ChatsAggregateRoot : IChatsAggregateRoot
{
	// Persistence
	ICollection<Chat> chats = new List<Chat>();

	public void ArchiveChat(int chatId)
	{
		var chat = getChatById(chatId);
		if(chat is not null) {
			chat.archived = true;
		}
	}

	public void CreateChat()
	{
		chats.Add(new Chat());
	}

	public void DeleteChat(int chatId)
	{
		var chat = getChatById(chatId);
		if(chat is not null) {
			chats.Remove(chat);
		}
	}

	public void JoinChat(int chatId, string chatterName)
	{
		var chat = getChatById(chatId);
		if(chat is not null) {
			var chatter = getChatterByName(chat, chatterName);
			if(chatter is not null) chat.chatters.Add(chatter);
		}
	}

	public void LeaveChat(int chatId, string chatterName)
	{
		var chat = getChatById(chatId);
		if(chat is not null) {
			var chatter = getChatterByName(chat, chatterName);
			if(chatter is not null) chat.chatters.Remove(chatter);
		}
	}

	public void PinChat(int chatId)
	{
		// TODO only pin for the chatter who requested it?
		var chat = getChatById(chatId);
		if(chat is not null) {
			chat.pinned = true;
		}
	}

	public void UnpinChat(int chatId)
	{
		// TODO only pin for the chatter who requested it?
		var chat = getChatById(chatId);
		if(chat is not null) {
			chat.pinned = false;
		}
	}

	private Chat? getChatById(int chatId) {
		return chats.Where<Chat>(c => c.chatId == chatId).FirstOrDefault();
	}

	private Chatter? getChatterByName(Chat chat, string chatterName) {
		return chat.chatters.Where<Chatter>(c => c.name == chatterName).FirstOrDefault();
	}
}

public class Chat {
	public int chatId;
	public bool archived;
	public bool pinned;
	public ICollection<Chatter> chatters = new List<Chatter>();
}

public class Chatter {
	public string? name;
}
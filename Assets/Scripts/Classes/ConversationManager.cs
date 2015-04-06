using UnityEngine;
using System.Collections;

public class ConversationManager : Singleton<ConversationManager> {

	// using singleton so there will only be one instance of conversation manager
	protected ConversationManager() {}

	// is therer conversation going on
	bool talking = false;

	// the current line of text being displayed
	ConversationEntry currentCoversationLine;

	// estimated width of characters in the font
	int fontSpacing = 7;

	// how wide is the conversation text box
	int conversationTextWidth;

	// height of the dialog text box
	int dialogHeight = 70;

	public void StartConversation(Conversation conversation) {

	}

	IEnumerator DisplayConversation(Conversation conversation) {
		talking = true;

		foreach (var conversationLine in conversation.ConversationLines) {
			currentCoversationLine = conversationLine;
			conversationTextWidth = conversationLine.ConversationText.Length * fontSpacing;

			yield return new WaitForSeconds(3);
		}
		talking = false;
	}

	void OnGUI() {
		if (talking) {
			// Layout Start
		
		}
	}
}

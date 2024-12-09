import { ActivityHandler, MessageFactory, TurnContext } from 'botbuilder';
import axios from 'axios';

export class EchoBot extends ActivityHandler {
    constructor() {
        super();
        // See https://aka.ms/about-bot-activity-message to learn more about the message and other activity types.
        this.onMessage(async (context, next) => {
            const userMessage = context.activity.text;
            const aiResponse = await this.getAIResponse(userMessage);
            await context.sendActivity(MessageFactory.text(aiResponse, aiResponse));
            // By calling next() you ensure that the next BotHandler is run.
            await next();
        });

        this.onMembersAdded(async (context, next) => {
            const membersAdded = context.activity.membersAdded;
            const welcomeText = 'Hello and welcome!';
            for (const member of membersAdded) {
                if (member.id !== context.activity.recipient.id) {
                    await context.sendActivity(MessageFactory.text(welcomeText, welcomeText));
                }
            }
            // By calling next() you ensure that the next BotHandler is run.
            await next();
        });
    }

    private async getAIResponse(message: string): Promise<string> {
        try {
            const response = await axios.post('https://your-ai-service-endpoint/api/v1', { message });
            return response.data.answer;
        } catch (error) {
            console.error('Error fetching AI response:', error);
            return 'Sorry, I am having trouble understanding you right now.';
        }
    }
}

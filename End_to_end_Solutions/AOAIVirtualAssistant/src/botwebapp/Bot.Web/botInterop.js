// JavaScript source code
window.botInterop = {
    sendMessage: async function (message) {
        const bot = new EchoBot();
        const response = await bot.getAIResponse(message);
        return response;
    }
};

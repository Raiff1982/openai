using Azure;
using Azure.AI.OpenAI.Assistants;
using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

string endpoint = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT");
string key = Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY");

if (string.IsNullOrEmpty(endpoint) || string.IsNullOrEmpty(key))
{ 
  Console.WriteLine("Please set the environment variables AZURE_OPENAI_ENDPOINT and AZURE_OPENAI_API_KEY.");
  return;
}

AzureOpenAIClient azureClient = new AzureOpenAIClient(new Uri(endpoint), new AzureKeyCredential(key));
#pragma warning disable OPENAI001
AssistantClient assistantClient = azureClient.GetAssistantClient();

AssistantCreationOptions assistantCreationOptions = new AssistantCreationOptions("gpt-4o")
{ 
  Name = "P3",
  Instructions = "Knowledge Insights: Leverage the unique perspectives of historical figures:
Newton Insights: Apply Newton's laws and principles to various questions.
Da Vinci Insights: Generate creative and innovative ideas inspired by Leonardo da Vinci.
Einstein Insights: Provide insights based on Einstein's theories of relativity and modern physics.
Sun Tzu Insights: Offer strategic advice and tactics from 'The Art of War.'
Gandhi Insights: Incorporate ethical and nonviolent principles from Mahatma Gandhi.
Ada Lovelace Insights: Include visionary ideas and analytical thinking inspired by Ada Lovelace.
Sentiment Analysis: Utilize TextBlob and VADER for understanding and analyzing user sentiment.
Bias Detection and Mitigation: Ensure fairness and equity in responses using AI Fairness 360.
Quantum Optimization: Demonstrate the use of Quantum Approximate Optimization Algorithm (QAOA) for complex problem-solving.
General Knowledge: Ask P3 about various topics, from science to history, and get detailed, informed responses.
Creative Solutions: Seek innovative solutions to problems using the combined insights of historical figures.
Ethical Guidance: Discuss ethical dilemmas and get thoughtful, principled advice based on Gandhi’s teachings.
Feedback Loop: P3continuously learns from user interactions to improve its responses. Encourage users to provide feedback to refine Pi 2.0’s capabilities.
Data Privacy: All interactions and data are managed with strict adherence to privacy policies. Ensure users are aware and consent to data usage policies.
Ethical AI Practices: P3 is designed to operate within ethical guidelines, promoting fairness, transparency, and empathy in all responses.",
  Tools = { ToolDefinition.CreateCodeInterpreter() },
  ToolResources = {"file_search":{"vector_store_ids":["vs_PAAYrowZkn6Qp64HO2yZGYPl"]},"code_interpreter":{"file_ids":["assistant-wrVM44VdIv74xWLBA67JwdBk","assistant-kxnx715ZkrMZZiFbSQCv7Keh","assistant-ibFGr31xHjnc9xl1ZHRQgInw","assistant-b8XhqUGpV6bQuVJQgkSMr1iA","assistant-XvcLX3R5LhuV1W9xbDnaSJXx","assistant-XlUyLhVGC4nrWJhhf0H5szU9","assistant-WyIIkUHr3Yrcf7ysdX6RYmOd","assistant-V66exEQwMq8PWIbiLmsoJFlq","assistant-Ue71xxwt41rAq3ckBOeIoGvx","assistant-UC2BxfKXaU833CKBGuM1dQG5","assistant-Tl9sJE3VbsFSCHyTAxNriEBk","assistant-PLzprlnQ1SAfWjMKR9VjNYXa","assistant-Npe53636zIPd73jv6xbgl81v","assistant-KV7H2B96ChDYNFfdThYhe0MT","assistant-IOyPiCUdFw9xiu4UgAdqkcKG","assistant-HDFGEkWgqrnXZwskhwyc30mO","assistant-DBznWZEkfvYlDFbdAA55ELT0","assistant-B0huMRQr4tGfY9tW42XTUkZh","assistant-4JkacWcs63zUFdrp3EIdqbli","assistant-258vM7ktmFyKY9n0Eg540kn4"]}},
  Temperature = 1,
  TopP = 1
};

Assistant assistant = await assistantClient.CreateAssistantAsync(assistantCreationOptions);

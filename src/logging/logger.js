require("dotenv").config(); // Load environment variables
const { MongoClient } = require("mongodb");

const uri = process.env.MONGO_URI; // Load MongoDB URI from .env file
const client = new MongoClient(uri);

// Function to Log Messages to MongoDB
async function logMessage(message) {
    try {
        await client.connect();
        const db = client.db("devops_db");
        const collection = db.collection("logs");

        await collection.insertOne({ message, timestamp: new Date() });
        console.log("Log saved to MongoDB:", message);
    } catch (error) {
        console.error("Error logging message:", error);
    } finally {
        await client.close();
    }
}

// Example Usage
logMessage("Server started successfully!");

module.exports = logMessage;


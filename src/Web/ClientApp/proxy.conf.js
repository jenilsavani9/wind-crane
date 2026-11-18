const { env } = require('process');

// Local API address (see src/Web/Properties/launchSettings.json). Override with API_URL.
const target = env["API_URL"] || "http://localhost:5289";

const PROXY_CONFIG = [
  {
    context: [
      "/api",
      "/openapi",
      "/scalar"
    ],
    target: target,
    secure: env["NODE_ENV"] !== "development",
  }
];

module.exports = PROXY_CONFIG;

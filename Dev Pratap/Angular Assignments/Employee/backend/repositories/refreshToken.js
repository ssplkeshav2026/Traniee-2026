const refreshToken = require("../module/RefreshTokenModel")


const saveRefreshToken = async (userId, tokenString, daysToLive = 7) => {
  try {
    const expiresAtDate = new Date();
    expiresAtDate.setDate(expiresAtDate.getDate() + daysToLive);

    const newSession = await RefreshToken.create({
      token: tokenString,
      userId: userId,
      expiresAt: expiresAtDate
    });

    return newSession;
  } catch (error) {
    console.error('Database insertion failed for Refresh Token:', error);
    throw error;
  }
};

module.exports = {
  saveRefreshToken
};
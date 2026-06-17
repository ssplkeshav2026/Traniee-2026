const jwt = require("jsonwebtoken")

const generateAccessToken = (user) => {
    console.log(user)
    return jwt.sign(
        {   
            userId: user.userId,
            fullName: user.fullName,
            email: user.email,
            role: user.role
        },
        process.env.ACCESS_TOKEN_SECRET,
        {
            expiresIn: "30m"
        }
    );
};

const generateRefreshToken = (user) => {
    return jwt.sign(
        {
            
            userId: user.UserID
        },
        process.env.REFRESH_TOKEN_SECRET,
        {
            expiresIn: "7d"
        }
    );
};

module.exports = {
    generateAccessToken, generateRefreshToken
}
const jwt =  require("jsonwebtoken") ;

authenticate = (req, res, next) => {
    try {
        const authHeader = req.headers.authorization;

        if (!authHeader) {
            return res.status(401).json({
                message: "Access token missing"
            });
        }

        const token = authHeader.split(" ")[1];
        
        const decoded = jwt.verify(
            token,
            process.env.ACCESS_TOKEN_SECRET
        );

        req.user = decoded;
        console.log(req.user)

        next();
    } catch (error) {
        return res.status(403).json({
            message: "Invalid or expired token"
        });
    }
}; 

module.exports = authenticate
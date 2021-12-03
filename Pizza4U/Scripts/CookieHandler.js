
class CookieHandler {
    construct() {

    }

    setCookie(cname, cvalue, minutes) {
        const d = new Date();
        d.setTime(d.getTime() + (minutes * 60 * 1000));
        let expires = "expires=" + d.toUTCString();
        document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
    }

    getCookieValue(name) {
        let result = document.cookie.match("(^|[^;]+)\\s*" + name + "\\s*=\\s*([^;]+)")
        return result ? result.pop() : ""
    }
    updateCookie(name, value) {
        let cookieValue = getCookieValue(name);
        console.log("Cookie Value From Update: " + cookieValue);
        document.cookie = "cartItems=" + cookieValue + value + ",";
    }

    deleteCookieValue(name) {
        this.updateCookie(name, "");
    }

    
}
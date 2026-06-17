let items= document.querySelectorAll(".item");

items.forEach(item => {
    const question = item.querySelector(".question");
    const answer = item.querySelector(".answer");

    question.addEventListener("click", () => {

        if (item.classList.contains("active")) {
            answer.style.height = answer.scrollHeight + "px";
            requestAnimationFrame(() => {
                answer.style.height = "0px";
            });
            item.classList.remove("active");
            return;
        }

        items.forEach(i => {
            const ans = i.querySelector(".answer");
            ans.style.height = "0px";
            i.classList.remove("active");
        });

        item.classList.add("active");
        answer.style.height = answer.scrollHeight + "px";
    });
});
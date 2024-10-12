function scrollToBottom(element) {
    if (element) {
        element.scrollTop = element.scrollHeight;
    }
}

function initializeChatRoom() {
    const chatInputContainer = document.querySelector('.chat-input-container');
    const chatMessages = document.querySelector('.chat-messages');

    function adjustLayout() {
        const viewportHeight = window.visualViewport.height;
        const windowHeight = window.innerHeight;

        if (viewportHeight < windowHeight) {
            // Keyboard is likely visible
            chatInputContainer.style.position = 'absolute';
            chatInputContainer.style.bottom = `${windowHeight - viewportHeight}px`;
        } else {
            // Keyboard is likely hidden
            chatInputContainer.style.position = 'fixed';
            chatInputContainer.style.bottom = '0';
        }

        chatMessages.style.paddingBottom = `${chatInputContainer.offsetHeight + 10}px`;
        scrollToBottom(chatMessages);
    }

    window.visualViewport.addEventListener('resize', adjustLayout);
    adjustLayout(); // Initial adjustment
}
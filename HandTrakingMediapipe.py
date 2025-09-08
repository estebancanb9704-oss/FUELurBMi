import cv2
import mediapipe as mp
import socket

# --- Setup UDP socket ---
sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
unity_address = ("127.0.0.1", 5052)  # Unity listens on this port

# --- Setup MediaPipe ---
mp_hands = mp.solutions.hands
mp_drawing = mp.solutions.drawing_utils
hands = mp_hands.Hands(max_num_hands=1, min_detection_confidence=0.7)

# --- Webcam ---
cap = cv2.VideoCapture(0)

def send_to_unity(message):
    sock.sendto(message.encode("utf-8"), unity_address)

while cap.isOpened():
    ret, frame = cap.read()
    if not ret:
        break

    # Flip image (mirror view) + convert to RGB
    frame = cv2.flip(frame, 1)
    rgb = cv2.cvtColor(frame, cv2.COLOR_BGR2RGB)

    # Detect hands
    results = hands.process(rgb)

    gesture = None
    if results.multi_hand_landmarks:
        for hand_landmarks in results.multi_hand_landmarks:
            mp_drawing.draw_landmarks(frame, hand_landmarks, mp_hands.HAND_CONNECTIONS)

            # Simple logic: if tip of index finger (id 8) is above MCP joint (id 5) → OPEN
            if hand_landmarks.landmark[8].y < hand_landmarks.landmark[5].y:
                gesture = "OPEN"
            else:
                gesture = "CLOSE"

    if gesture:
        send_to_unity(gesture)
        cv2.putText(frame, f"Gesture: {gesture}", (30, 50),
                    cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 255, 0), 2)

    # Show video
    cv2.imshow("MediaPipe Hands", frame)

    if cv2.waitKey(5) & 0xFF == 27:  # ESC key to quit
        break

cap.release()
cv2.destroyAllWindows()

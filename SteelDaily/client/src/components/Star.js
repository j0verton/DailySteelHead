import React from "react";

function Star({ outcome }) {
    return (
        <svg transform="scale(.5)" width={150} height={175}>
            <path
                transform="translate(-10) scale(.6)"
                fill={outcome ? "#fdff00" : "#808080"}
                stroke="#605a00"
                strokeWidth={15}
                d="M150 25l29 86h90l-72 54 26 86-73-51-73 51 26-86-72-54h90z"
            />
        </svg >
    );
}

export default Star;

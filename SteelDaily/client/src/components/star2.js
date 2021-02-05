import * as React from "react";

function Star2(props) {
    return (
        <svg width={300} height={275} {...props}>
            <path
                fill="#fdff00"
                stroke="#605a00"
                strokeWidth={15}
                d="M150 25l29 86h90l-72 54 26 86-73-51-73 51 26-86-72-54h90z"
            />
        </svg>
    );
}

const MemoStar2 = React.memo(Star2);
export default MemoStar2;

import React, { useState, createContext, useContext } from "react";
import { UserProfileContext } from "./UserProfileProvider";


export const StreakContext = createContext();

export function StreakProvider(props) {
    const { getToken } = useContext(UserProfileContext)
    const [streak, setStreak] = useState();

    const getStreak = () => {
        getToken().then((token) => {
            return fetch(`/api/streak`, {
                method: "GET",
                headers: {
                    Authorization: `Bearer ${token}`,
                },
            })
        }).then(res => res.json())
            .then(res => {
                console.log(res)
                setStreak(res)
            })
    }

    return (
        <StreakContext.Provider value={{ streak, getStreak }}>
            {props.children}
        </StreakContext.Provider>

    )
}
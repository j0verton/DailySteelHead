import React, { useState, useEffect, createContext, useContext } from "react";
import { UserProfileContext } from "./UserProfileProvider";


export const StreakContext = createContext();

export function StreakProvider(props) {
    const { getToken } = useContext(UserProfileContext)
    const [streak, setStreak] = useState();

    useEffect(() => {
        getStreak()
    }, []);

    const getStreak = () => {
        getToken().then((token) => {
            return fetch(`/api/streak`, {
                method: "GET",
                headers: {
                    Authorization: `Bearer ${token}`,
                },
            })
        }).then(setStreak)
    }

    return (
        <StreakContext.Provider value={{ streak, getStreak }}></StreakContext.Provider>

    )
}